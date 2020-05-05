using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WritingExporter.Common.Configuration;
using WritingExporter.Common.Data.Repositories;
using WritingExporter.Common.Events;
using WritingExporter.Common.Events.WritingExporter.Common.Events;
using WritingExporter.Common.Exceptions;
using WritingExporter.Common.File_Dumper;
using WritingExporter.Common.Logging;
using WritingExporter.Common.Models;
using WritingExporter.Common.Wdc;

namespace WritingExporter.Common.WdcSync
{
    public class WdcSyncWorker : IDisposable, IEventSubscriber<WdcSyncWorkerCommandEvent>
    {
        const int THINK_INVERVAL_MS = 1000;

        ILogger _log;
        ConfigService _config;
        EventHub _eventHub;
        FileDumperService _fileDumper;
        WdcClient _wdcClient;
        WdcReaderFactory _wdcReaderFactory;
        WdcStoryRepository _storyRepo;
        WdcChapterRepository _chapterRepo;
        Task _workerThread;
        CancellationTokenSource _ctSource = new CancellationTokenSource();
        DateTime _lastThink;
        bool _disposing;
        bool _syncEnabled = true;

        string _currentStorySysId;
        string _currentStoryId;
        string _currentChapterSysId;
        string _currentChapterId;

        WdcSyncWorkerStatus _currentStatus;
        object _statusLock = new object();
        object _commandLock = new object();

        public WdcSyncWorker(
            ILoggerSource loggerSource, ConfigService config, EventHub eventHub,
            WdcStoryRepository storyRepo, WdcChapterRepository chapterRepo,
            WdcClient wdcClient, WdcReaderFactory wdcReaderFactory,
            FileDumperService fileDumper
            )
        {
            _log = loggerSource.GetLogger(typeof(WdcSyncWorker));
            _config = config;
            _eventHub = eventHub;
            _storyRepo = storyRepo;
            _chapterRepo = chapterRepo;
            _wdcClient = wdcClient;
            _wdcReaderFactory = wdcReaderFactory;
            _fileDumper = fileDumper;

            // Subscribe to events
            _eventHub.Subscribe<WdcSyncWorkerCommandEvent>(this);

            UpdateWorkerStatus(WdcSyncWorkerState.WorkerIdle, string.Empty, "Worker hasn't started yet");
        }

        public Task HandleEventAsync(WdcSyncWorkerCommandEvent @event)
        {
            _log.Debug($"Received command: {@event.CommandType.ToString()}");

            lock (_commandLock)
            {
                switch (@event.CommandType)
                {
                    case WdcSyncWorkerCommandEventType.RequestStatusUpdate:
                        _log.Debug("Status update requested");
                        PublishSyncWorkerStatus();
                        break;
                    case WdcSyncWorkerCommandEventType.StartWorker:
                        _syncEnabled = true;
                        Start();
                        break;
                    case WdcSyncWorkerCommandEventType.StopWorker:
                        _syncEnabled = false;
                        Cancel();
                        break;
                }
            }
            
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Stop();
        }

        public void EnableSync(bool a)
        {
            _syncEnabled = a;
        }

        public void Start()
        {
            if (_workerThread != null && !_workerThread.IsCompleted) {
                _log.Warn("Trued to start a sync worker but it's already started");
                //throw new InvalidOperationException("Tried to start the sync worker but it's already started");
            }

            Task newThread = new Task(ThinkFunction);
            newThread.Start();
            _workerThread = newThread;
        }

        public void Stop()
        {
            _disposing = true;
            Cancel();
        }

        public void Cancel()
        {
            if (_ctSource != null && !_ctSource.IsCancellationRequested)
            {
                _ctSource.Cancel();
            }

            _ctSource = new CancellationTokenSource();
        }

        void UpdateWorkerStatus(WdcSyncWorkerState workerState, string workerCurrentTask, string workerMessage)
        {
            lock (_statusLock)
            {
                _log.Debug($"Status change. {workerState.ToString()} {workerMessage} ({workerCurrentTask})");

                _currentStatus = new WdcSyncWorkerStatus()
                {
                    State = workerState,
                    CurrentTask = workerCurrentTask,
                    Message = workerMessage
                };

                PublishSyncWorkerStatus();
            }
        }

        public WdcSyncWorkerStatus GetWorkerStatus()
        {
            lock (_statusLock)
            {
                return _currentStatus.DeepClone();
            }
        }

        void PublishSyncWorkerStatus()
        {
            _eventHub.PublishEvent(new WdcSyncWorkerEvent(_currentStatus.DeepClone()));
        }

        bool IsSyncEnabled()
        {
            return IsSyncEnabled(_config.GetSection<WdcSyncConfigSection>());
        }

        bool IsSyncEnabled(WdcSyncConfigSection config)
        {
            return (config.SyncEnabled && _syncEnabled);
        }

        async void ThinkFunction()
        {
            if (!IsSyncEnabled())
            {
                UpdateWorkerStatus(WdcSyncWorkerState.WorkerIdle, string.Empty, "Sync worker not enabled, check options");
            }

            WdcSyncConfigSection config;

            while(IsSyncEnabled()) // Infinite loop of death
            {
                _log.Debug("Think");

                config = _config.GetSection<WdcSyncConfigSection>();

                // Pause if required
                var nextThink = _lastThink.AddMilliseconds(THINK_INVERVAL_MS);

                if (DateTime.Now < nextThink)
                {
                    // Pause until the next think
                    
                    UpdateWorkerStatus(WdcSyncWorkerState.WorkerIdle, string.Empty, $"Idle until {nextThink.ToLongTimeString()}");
                    Thread.Sleep(nextThink - DateTime.Now);
                }

                // Think has officially started
                _lastThink = DateTime.Now;

                // Cancellation and exception handling
                try
                {
                    var wdcConfig = _config.GetSection<WdcClientConfigSection>();
                    if (string.IsNullOrEmpty(wdcConfig.WritingUsername))
                        throw new Exception("WDC username cannot be empty");
                    if (string.IsNullOrEmpty(wdcConfig.WritingPassword))
                        throw new Exception("WDC password cannot be empty");

                    var ct = _ctSource.Token;
                    ct.ThrowIfCancellationRequested();

                    // Look for stories that need syncing (NextSync is in the past)
                    UpdateWorkerStatus(WdcSyncWorkerState.WorkerIdle, string.Empty, "Checking for things to do");
                    var workQueueStories = _storyRepo.GetStoriesNeedingSync(DateTime.Now)
                        .Where(s => s.State != WdcStoryState.Error && s.State != WdcStoryState.Disabled)
                        .Select(s => s.SysId);

                    _log.Debug($"Stories to sync ({workQueueStories.Count()}): {string.Join(",", workQueueStories)}");

                    // Sync the stories
                    foreach (var storySysId in workQueueStories)
                    {
                        _log.Debug($"Synching story: {storySysId}");

                        WdcStory story;
                        try
                        {
                            story = _storyRepo.GetByID(storySysId);

                            // TODO handle if can't find the story anymore
                        }
                        catch (Exception ex)
                        {
                            // DEBUG just for testing, throw the exception
                            throw ex;
                        }

                        _currentStorySysId = storySysId;
                        _currentStoryId = story.Id;
                        _currentChapterSysId = "";
                        _currentChapterId = "";

                        UpdateWorkerStatus(WdcSyncWorkerState.WorkerWorking, story.Id, "Syncing story");
                        _eventHub.PublishEvent(new WdcSyncStoryEvent(WdcSyncStoryEventType.StorySyncStarted, storySysId, story.Id, "Syncing story"));

                        try
                        {
                            // Get the story
                            story.State = WdcStoryState.Syncing;
                            story.StateMessage = string.Empty;
                            _storyRepo.Save(story);

                            // Sync the story info
                            if (story.LastUpdatedInfo <= DateTime.Now.AddSeconds(-config.SyncStoryInfoIntervalSeconds))
                            {
                                _log.Debug($"Synching story info: {storySysId}");
                                UpdateWorkerStatus(WdcSyncWorkerState.WorkerWorking, story.Id, "Syncing story info");
                                _eventHub.PublishEvent(new WdcSyncStoryEvent(WdcSyncStoryEventType.StorySyncStarted, storySysId, story.Id, "Syncing story info"));
                                await SyncStoryInfo(story.SysId, _ctSource.Token);

                                // Update timestamp
                                story = _storyRepo.GetByID(storySysId);
                                story.LastUpdatedInfo = DateTime.Now;
                                _storyRepo.Save(story);
                            } 
                            else
                            {
                                _log.Debug($"Story info does not need syncing: {storySysId}");
                            }


                            // Sync the story chapter map
                            if (story.LastUpdatedChapterOutline <= DateTime.Now.AddSeconds(-config.SyncChapterOutlineIntervalSeconds))
                            {
                                _log.Debug($"Syncing story chapter outline: {storySysId}");
                                UpdateWorkerStatus(WdcSyncWorkerState.WorkerWorking, story.Id, "Syncing chapter outline");
                                _eventHub.PublishEvent(new WdcSyncStoryEvent(WdcSyncStoryEventType.StorySyncStarted, storySysId, story.Id, "Syncing chapter outline"));
                                await SyncChapterOutline(story.SysId, story.Id, _ctSource.Token);

                                // Update timestamp
                                story = _storyRepo.GetByID(storySysId);
                                story.LastUpdatedChapterOutline = DateTime.Now;
                                _storyRepo.Save(story);
                            }
                            else
                            {
                                _log.Debug($"Story chapter outline does not need syncing: {storySysId}");
                            }

                            // Look for chapters that need syncing
                            var timestamp = DateTime.Now.AddSeconds(-config.SyncChapterIntervalSeconds);
                            var workQueueChapters = _chapterRepo.GetStoryChapterNotSyncedSince(storySysId, timestamp).Select(c => c.SysId);
                            foreach (string chapterSysId in workQueueChapters)
                            {
                                ct.ThrowIfCancellationRequested();

                                // Sync chapters
                                _currentChapterSysId = chapterSysId;

                                try
                                {
                                    await SyncChapter(chapterSysId, _ctSource.Token);
                                }
                                catch (WdcReaderHtmlParseException ex)
                                {
                                    var exMsg = new StringBuilder();
                                    exMsg.AppendLine($"Exception encountered while syncing chapter {_currentStoryId}:{_currentChapterId}");

                                    // Dump it
                                    if (ex.Data.Contains(WdcReader.PARSE_EXCEPTION_HTML_PAYLOAD_KEY))
                                    {
                                        var result = _fileDumper.DumpFile(
                                            $"{_fileDumper.GetTimestampForPath(DateTime.Now)} story {_currentStoryId} chapter {_currentChapterId}.html",
                                            ex.Data[WdcReader.PARSE_EXCEPTION_HTML_PAYLOAD_KEY].ToString()
                                            );
                                        exMsg.AppendLine($"The HTML of the file has been dumped to: {result.Filename}");
                                        exMsg.AppendLine();
                                    }

                                    _log.Error(exMsg.ToString(), ex);

                                    _eventHub.PublishEvent(new ExceptionAlertEvent(this, ex, exMsg.ToString()));

                                    var msg = $"Exception encountered while syncing chapter {_currentChapterId}\n{ex.GetType().ToString()}\n{ex.Message}";

                                    story = _storyRepo.GetByID(storySysId);
                                    story.LastSynced = DateTime.Now;
                                    story.State = WdcStoryState.Error;
                                    story.StateMessage = msg;

                                    _storyRepo.Save(story);

                                    _eventHub.PublishEvent(new WdcSyncStoryEvent(WdcSyncStoryEventType.StorySyncException, storySysId, story.Id, msg));

                                    Cancel();
                                }
                                finally
                                {
                                    _currentChapterId = string.Empty;
                                    _currentChapterSysId = string.Empty;
                                }
                                
                            }

                            // Sync completed without issue
                            // Update LastSynced timestamp on story
                            _log.Debug($"Sync complete for story {storySysId}");
                            story = _storyRepo.GetByID(storySysId);
                            story.State = WdcStoryState.Idle;
                            story.StateMessage = string.Empty;
                            story.LastSynced = DateTime.Now;
                            story.NextSync = DateTime.Now.AddSeconds(config.SyncStoryIntervalSeconds);
                            _storyRepo.Save(story);

                            _eventHub.PublishEvent(new WdcSyncStoryEvent(WdcSyncStoryEventType.StorySyncComplete, storySysId, story.Id, string.Empty));
                        }
                        catch (InteractivesTemporarilyUnavailableException ex)
                        {
                            string msg = $"ITU encountered, pausing for {config.ItuPauseDuration}s";

                            _log.Info(msg);
                            story = _storyRepo.GetByID(storySysId);
                            story.LastSynced = DateTime.Now;
                            story.NextSync = DateTime.Now.AddSeconds(config.ItuPauseDuration);
                            story.State = WdcStoryState.IdleItuPause;
                            story.StateMessage = msg;

                            _storyRepo.Save(story);

                            _eventHub.PublishEvent(new WdcSyncStoryEvent(WdcSyncStoryEventType.StorySyncIncomplete, storySysId, story.Id, "ITU encountered, pausing"));
                        }
                        catch (WdcReaderHtmlParseException ex)
                        {
                            var exMsg = new StringBuilder();
                            exMsg.AppendLine($"Exception encountered while syncing story {storySysId}");

                            if (ex.Data.Contains(WdcReader.PARSE_EXCEPTION_HTML_PAYLOAD_KEY))
                            {
                                var result = _fileDumper.DumpFile(
                                    $"{_fileDumper.GetTimestampForPath(DateTime.Now)} story {_currentStoryId}.html", 
                                    ex.Data[WdcReader.PARSE_EXCEPTION_HTML_PAYLOAD_KEY].ToString()
                                    );
                                exMsg.AppendLine($"The HTML of the file has been dumped to: {result.Filename}");
                                exMsg.AppendLine();
                            }

                            _log.Error(exMsg.ToString(), ex);
                            _eventHub.PublishEvent(new ExceptionAlertEvent(this, ex, exMsg.ToString()));

                            var msg = $"Exception encountered during sync\n{ex.GetType().ToString()}\n{ex.Message}";

                            story = _storyRepo.GetByID(storySysId);
                            story.LastSynced = DateTime.Now;
                            story.State = WdcStoryState.Error;
                            story.StateMessage = msg;

                            _storyRepo.Save(story);

                            _eventHub.PublishEvent(new WdcSyncStoryEvent(WdcSyncStoryEventType.StorySyncException, storySysId, story.Id, msg));
                        }
                        // Don't catch any other exceptions
                        // This will likely not be story-specific, and should be handled at the SyncWorker level
                        finally
                        {
                            // Try to clear any syncing states on stories
                            if (!string.IsNullOrEmpty(_currentStoryId))
                            {
                                var __story = _storyRepo.GetByID(_currentStoryId);
                                if (__story != null)
                                {
                                    __story.State = WdcStoryState.Idle;
                                    __story.StateMessage = "";
                                    _storyRepo.Save(__story);
                                }
                            }

                            _currentStorySysId = string.Empty;
                            _currentStoryId = string.Empty;
                        }
                    }

                }
                catch (OperationCanceledException ex)
                {
                    _log.Debug("Sync cancelled");
                    UpdateWorkerStatus(WdcSyncWorkerState.WorkerIdle, string.Empty, "Sync cancelled");
                }
                catch (Exception ex)
                {
                    // Disable sync worker
                    _syncEnabled = false;

                    _log.Error("Exception encountered in sync worker", ex);
                    UpdateWorkerStatus(WdcSyncWorkerState.WorkerError, string.Empty, 
                        $"Exception encountered in sync worker:\n{ex.GetType().ToString()}\n{ex.Message}");

                    _eventHub.PublishEvent(new ExceptionAlertEvent(this, ex, "Exception encountered in sync worker"));
                }
                finally
                {
                    // Try to clear any syncing states on stories
                    if (!string.IsNullOrEmpty(_currentStoryId))
                    {
                        var __story = _storyRepo.GetByID(_currentStoryId);
                        if (__story != null)
                        {
                            __story.State = WdcStoryState.Idle;
                            __story.StateMessage = "";
                            _storyRepo.Save(__story);
                        }
                    }

                    _currentStorySysId = string.Empty;
                    _currentStoryId = string.Empty;
                }

                // Should I end things?
                if (_disposing)
                {
                    _log.Debug("Disposing, ending think loop");
                    return;
                }
            }
        }

        async Task SyncStoryInfo(string storySysId, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            
            var wdcReader = _wdcReaderFactory.GetReader();

            // Get the current story info
            var currentStory = _storyRepo.GetByID(storySysId);

            // Get the story info from WDC
            // And exception handle
            WdcResponse response;
            try
            {
                response = await _wdcClient.GetInteractiveHomepage(currentStory.Id, ct);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ct.ThrowIfCancellationRequested();

            var newStory = wdcReader.GetInteractiveStory(response.WebResponse, currentStory.Id, response.Address);

            if (
                currentStory.AuthorName != newStory.AuthorName ||
                currentStory.AuthorUsername != newStory.AuthorUsername ||
                currentStory.Description != newStory.Description ||
                currentStory.ShortDescription != newStory.ShortDescription ||
                currentStory.Url != newStory.Url
                )
            {
                _log.Debug($"Updating story with new content: {currentStory.Id}");

                // Details are different
                currentStory.AuthorName = newStory.AuthorName;
                currentStory.AuthorUsername = newStory.AuthorUsername;
                currentStory.Description = newStory.Description;
                currentStory.ShortDescription = newStory.ShortDescription;
                currentStory.Url = newStory.Url;
                currentStory.LastUpdatedInfo = DateTime.Now;

                ct.ThrowIfCancellationRequested();

                _storyRepo.Save(currentStory);
            }
        }

        async Task SyncChapterOutline(string storySysId, string storyId, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var chaptersToAdd = new List<string>();

            var wdcReader = _wdcReaderFactory.GetReader();

            // Get the current chapter map, just need a list of paths
            var currentChapterPaths = _chapterRepo.GetStoryChapters(storySysId).Select(c => c.Path);

            // Get the chapter map from WDC
            // And exception handle
            WdcResponse response;
            try
            {
                response = await _wdcClient.GetInteractiveOutline(storyId, ct);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ct.ThrowIfCancellationRequested();

            // Compare to current chapters
            var newChapterPaths = wdcReader.GetInteractiveChapterList(storyId, response.WebResponse);
            foreach (Uri newChapterPath in newChapterPaths)
            {
                var path = WdcUtil.GetFinalParmFromUrl(newChapterPath);
                if (!currentChapterPaths.Contains(path))
                {
                    chaptersToAdd.Add(path);
                }
            }

            // Add the chapters
            var newChapters = new List<WdcChapter>(capacity: newChapterPaths.Count());
            foreach (var newChapterPath in chaptersToAdd)
            {
                _log.Debug($"Adding missing chapter {newChapterPath} for story {storySysId}");
                newChapters.Add(new WdcChapter()
                {
                    Path = newChapterPath,
                    StoryId = storySysId
                });
            }

            ct.ThrowIfCancellationRequested();

            _chapterRepo.AddRange(newChapters);
        }

        async Task SyncChapter(string chapterSysId, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var wdcReader = _wdcReaderFactory.GetReader();

            // Get the current story info
            var currentChapter = _chapterRepo.GetByID(chapterSysId);

            _currentChapterId = currentChapter.Path;

            // TODO handle if can't find the chapter anymore

            var msg = $"Syncing chapter {currentChapter.Path}";
            UpdateWorkerStatus(WdcSyncWorkerState.WorkerWorking, _currentStoryId, msg);
            _eventHub.PublishEvent(new WdcSyncStoryEvent(WdcSyncStoryEventType.StorySyncStarted, _currentStorySysId, _currentStoryId, msg));

            // Get the chapter info from WDC
            // And exception handle
            WdcResponse response;
            try
            {
                response = await _wdcClient.GetInteractiveChapter(_currentStoryId, currentChapter.Path, ct); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ct.ThrowIfCancellationRequested();

            WdcChapter newChapter = wdcReader.GetInteractiveChapter(response.Address, response.WebResponse);

            if (
                currentChapter.AuthorName != newChapter.AuthorName ||
                currentChapter.AuthorUsername != newChapter.AuthorUsername ||
                currentChapter.Content != newChapter.Content ||
                currentChapter.IsEnd != newChapter.IsEnd ||
                currentChapter.Path != newChapter.Path ||
                currentChapter.SourceChoiceTitle != newChapter.SourceChoiceTitle ||
                currentChapter.Title != newChapter.Title
                )
            {
                _log.Debug($"Updating chapter with new content: {_currentStoryId}:{currentChapter.Path}");

                // Details are different
                currentChapter.AuthorName = newChapter.AuthorName;
                currentChapter.AuthorUsername = newChapter.AuthorUsername;
                currentChapter.Content = newChapter.Content;
                currentChapter.IsEnd = newChapter.IsEnd;
                currentChapter.Path = newChapter.Path;
                currentChapter.SourceChoiceTitle = newChapter.SourceChoiceTitle;
                currentChapter.Title = newChapter.Title;
                currentChapter.LastUpdated = DateTime.Now;

                ct.ThrowIfCancellationRequested();

                _chapterRepo.Save(currentChapter);
            }
        }
    }
}

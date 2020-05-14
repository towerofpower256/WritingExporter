using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Models;
using System.IO;
using WritingExporter.Common.Logging;
using WritingExporter.Common.Data.Repositories;
using System.Threading;
using System.Runtime.Remoting.Channels;

namespace WritingExporter.Common.Export
{
    /// <summary>
    /// <para>Use this to export stories to a collection of HTML files, 1 file per page.</para>
    /// <para>Note that this will cause issues if the chapter path is over ~200 levels deep. It will breach the 255 character filename limit.</para>
    /// </summary>
    // NOTE: The map depth limit won't be circumvented by sticking them in an archive file, they have about the same file size restriction.
    // Possible solution: The map depth limit may be circumvented by naming the files with a GUID. It will
    //     make the file names less human readable, but it would work. I'll leave it for the future.
    //     I'm hoping that writing.com has a similar limitation, and this issue won't ever be encountered.
    public class WdcStoryExporterHtmlCollection : IWdcStoryExporter
    {
        private const string HTML_TEMPLATE_ROOT = "WritingExporter.Common.Export.HtmlCollectionTemplates."; // Update this if the templates ever move.
        private const string STORY_HOMEPAGE_FILENAME = "index.html";
        private const string STORY_OUTLINE_FILENAME = "outline.html";
        private const string STORY_RECENT_CHAPTERS_FILENAME = "recent_chapters.html";
        private const string STORY_CHAPTER_FILENAME = "chapter-{0}.html";
        private const string CHAPTER_NOT_EXPORTED_PLACEHOLDER = "(chapter hasn't been exported)";

        public static ILogger _log;

        public event EventHandler<WdcStoryExporterProgressUpdateArgs> OnProgressUpdate;

        private string _outputDir;
        private Dictionary<string, string> _chapterPathFilenames;
        private int _progressValue;
        private int _progressMax;
        private string _lastMessage;
        private WdcStory _story;
        private WdcChapterOutline[] _chapterOutline;
        WdcStoryRepository _storyRepo;
        WdcChapterRepository _chapterRepo;
        CancellationTokenSource _ctSource;

        public WdcStoryExporterHtmlCollection(ILoggerSource loggerSource, WdcStoryRepository storyRepo, WdcChapterRepository chapterRepo)
        {
            _log = loggerSource.GetLogger(typeof(WdcStoryExporterHtmlCollection));
            _storyRepo = storyRepo;
            _chapterRepo = chapterRepo;

            // TODO cancellation handling
        }

        public void Cancel()
        {
            _ctSource?.Cancel();
        }

        private void DoProgressUpdate(WdcStoryExporterProgressUpdateState state, string msg, int progressValue, int progressMax)
        {
            DoProgressUpdate(state, msg, null, progressValue, progressMax);
        }

        private void DoProgressUpdate(WdcStoryExporterProgressUpdateState state, string msg, Exception ex, int progressValue = 0, int progressMax = 0)
        {
            msg = string.IsNullOrEmpty(msg) ? _lastMessage : msg;
            _progressValue = progressValue;
            _progressMax = progressMax;

            OnProgressUpdate?.Invoke(this, new WdcStoryExporterProgressUpdateArgs()
            {
                Sender = this,
                State = state,
                ProgressMax = progressMax,
                ProgressValue = progressValue,
                Message = msg,
                Exception = ex
            });
        }

        public WdcStoryExporterResults ExportStory(string storySysid, string outputDir)
        {
            _ctSource = new CancellationTokenSource();
            var ct = _ctSource.Token;

            try
            {
                _outputDir = outputDir;
                _progressMax = 0;
                _chapterPathFilenames = new Dictionary<string, string>();

                ct.ThrowIfCancellationRequested();
                _story = _storyRepo.GetByID(storySysid);
                if (_story == null)
                    throw new ArgumentException($"Cannot find story using the SysId '{storySysid}'", storySysid);

                _log.InfoFormat($"Exporting story '{_story.Id}' to path: {_outputDir}");

                DoProgressUpdate(WdcStoryExporterProgressUpdateState.Working, "Getting ready to export", 0, 0);

                // Get the chapter outline for the story
                ct.ThrowIfCancellationRequested();
                _chapterOutline = _chapterRepo.GetStoryOutline(storySysid).ToArray();
                _progressMax = _chapterOutline.Length;

                // Build chapter file names
                // Do it this way and don't implicitly use the chapter's path, because this can get LOOOOOOOONG.
                // So long that Windows complains about it.
                DoProgressUpdate(WdcStoryExporterProgressUpdateState.Working, "Preparing chapter file names", 0, 0);
                foreach (var co in _chapterOutline)
                {
                    _chapterPathFilenames[co.Path] = GetChapterFileName(co.Path);
                }

                // Create the missing directories, if need be
                ct.ThrowIfCancellationRequested();
                Directory.CreateDirectory(_outputDir);


                DoProgressUpdate(WdcStoryExporterProgressUpdateState.Working, "Exporting story homepage", 0, _progressMax);
                ExportStoryHomepage(_story);

                DoProgressUpdate(WdcStoryExporterProgressUpdateState.Working, "Exporting story outline", 0, _progressMax);
                ExportStoryOutline(_story, _chapterOutline);

                DoProgressUpdate(WdcStoryExporterProgressUpdateState.Working, "Exporting recent chapters", 0, _progressMax);
                ExportStoryRecentChapters(_story, _chapterOutline);

                //foreach (var chapter in story.Chapters)
                for (var i = 0; i < _chapterOutline.Length; i++)
                {
                    var chapterOutline = _chapterOutline[i];
                    var chapter = _chapterRepo.GetByID(chapterOutline.SysId);
                    var chapterIsReady = IsChapterReady(chapter);
                    DoProgressUpdate(WdcStoryExporterProgressUpdateState.Working, $"Exporting chapter {chapter.Path}", i, _progressMax);
                    if (chapterIsReady) ExportStoryChapter(_story, chapter, _chapterPathFilenames[chapter.Path]);
                }

                DoProgressUpdate(WdcStoryExporterProgressUpdateState.Completed, "Export complete", _progressMax, _progressMax);
                return new WdcStoryExporterResults(this, storySysid, WdcStoryExporterResultsState.Completed, outputDir, null);
            }
            catch (OperationCanceledException)
            {
                DoProgressUpdate(WdcStoryExporterProgressUpdateState.Cancelled, "Export cancelled", _progressMax, _progressMax);
                return new WdcStoryExporterResults(this, storySysid, WdcStoryExporterResultsState.Cancelled, outputDir, null);
            }
            catch (Exception ex)
            {
                DoProgressUpdate(WdcStoryExporterProgressUpdateState.Error, "Exception while exporting story", ex);
                return new WdcStoryExporterResults(this, storySysid, WdcStoryExporterResultsState.Exception, outputDir, ex);
            }
        }

        public void ExportStoryHomepage(WdcStory story)
        {
            var ct = _ctSource.Token;
            ct.ThrowIfCancellationRequested();

            _log.Debug("Exporting story homepage");

            string htmlContent = GetTemplate("StoryHomepage.html")
                .Replace("{StoryTitle}", story.Name)
                //.Replace("{StoryAuthor}", story.Author.Name) // Author isn't currently supported
                .Replace("{StoryShortDescription}", story.ShortDescription)
                .Replace("{StoryDescription}", story.Description)
                .Replace("{FirstPageLink}", _chapterPathFilenames["1"])
                .Replace("{StoryOutlineLink}", GetOutlineFileName())
                .Replace("{RecentChaptersLink}", GetRecentChaptersFileName());

            var html = GetPageTemplate(story.Name, story.Name, htmlContent);

            var fname = GetHomepageFileName();

            ct.ThrowIfCancellationRequested();
            File.WriteAllText(Path.Combine(_outputDir, fname), html);
        }

        public void ExportStoryOutline(WdcStory story, IEnumerable<WdcChapterOutline> chapters)
        {
            var ct = _ctSource.Token;
            ct.ThrowIfCancellationRequested();

            _log.Debug("Exporting story outline");

            StringBuilder htmlStoryOutline = new StringBuilder();

            var chaptersStorted = chapters.OrderBy(c => c.Path);
            foreach (var chapter in chaptersStorted)
            {
                var chapterIsReady = IsChapterOutlineReady(chapter);
                htmlStoryOutline.AppendLine(
                    GetTemplate("StoryOutlineItem.html")
                    .Replace("{ChapterPathDisplay}", GetPrettyChapterPath(chapter.Path))
                    .Replace("{ChapterPath}", chapter.Path)
                    .Replace("{ChapterName}", chapterIsReady ? chapter.Title : CHAPTER_NOT_EXPORTED_PLACEHOLDER)
                    .Replace("{ChapterLink}", chapterIsReady ? _chapterPathFilenames[chapter.Path] : "#")
                    );
            }

            string htmlContent = GetTemplate("StoryOutline.html")
                .Replace("{StoryTitle}", story.Name)
                .Replace("{OutlineContent}", htmlStoryOutline.ToString())
                .Replace("{HomeLink}", GetHomepageFileName());

            var html = GetPageTemplate($"{story.Name} - Chapter outline", "Chapter outline", htmlContent);

            var fname = GetOutlineFileName();

            ct.ThrowIfCancellationRequested();
            File.WriteAllText(Path.Combine(_outputDir, fname), html);
        }

        public void ExportStoryRecentChapters(WdcStory story, IEnumerable<WdcChapterOutline> chapters)
        {
            var ct = _ctSource.Token;
            ct.ThrowIfCancellationRequested();

            _log.Debug("Exporting story recent chapters");

            var chaptersStorted = chapters.OrderByDescending(c => c.FirstSeen);

            var htmlRecentChaptersItems = new StringBuilder();
            foreach (var chapter in chaptersStorted)
            {
                var chapterIsReady = IsChapterOutlineReady(chapter);

                htmlRecentChaptersItems.AppendLine(
                    GetTemplate("StoryRecentChaptersItem.html")
                    .Replace("{ChapterName}", chapterIsReady ? chapter.Title : CHAPTER_NOT_EXPORTED_PLACEHOLDER)
                    .Replace("{ChapterSeen}", chapter.FirstSeen.ToString())
                    .Replace("{ChapterPath}", GetPrettyChapterPath(chapter.Path))
                    .Replace("{ChapterLink}", chapterIsReady ? _chapterPathFilenames[chapter.Path] : "#")
                    );
            }

            string htmlContent = GetTemplate("StoryRecentChapters.html")
                .Replace("{StoryTitle}", story.Name)
                .Replace("{RecentChapterItems}", htmlRecentChaptersItems.ToString())
                .Replace("{HomeLink}", GetHomepageFileName());

            var html = GetPageTemplate($"{story.Name} - Recent chapters", "Recent chapters", htmlContent);

            var fname = GetRecentChaptersFileName();

            ct.ThrowIfCancellationRequested();
            File.WriteAllText(Path.Combine(_outputDir, fname), html);
        }

        public void ExportStoryChapter(WdcStory story, WdcChapter chapter, string filename)
        {
            var ct = _ctSource.Token;
            ct.ThrowIfCancellationRequested();

            _log.DebugFormat("Exporting chapter: {0}", chapter.Path);

            var chapterIsReady = IsChapterReady(chapter);
            var htmlContent = GetTemplate("Chapter.html")
                .Replace("{AuthorName}", $"{chapter.AuthorName} ({chapter.AuthorUsername})")
                .Replace("{ChapterPath}", chapter.Path)
                .Replace("{ChapterPathDisplay}", GetPrettyChapterPath(chapter.Path))
                .Replace("{SourceChapterChunk}", GetPreviousChapterLink(story, chapter))
                .Replace("{ChapterChoices}", GetChapterChoices(story, chapter))
                .Replace("{ChapterContent}", chapter.Content)
                .Replace("{ChapterTitle", chapter.Title)
                .Replace("{HomeLink}", GetHomepageFileName());

            var html = GetPageTemplate($"{story.Name} - {chapter.Title}", chapter.Title, htmlContent);

            // TODO: Fix the "Go back" link

            ct.ThrowIfCancellationRequested();

            File.WriteAllText(Path.Combine(_outputDir, filename), html);
        }

        private string GetPreviousChapterLink(WdcStory story, WdcChapter chapter)
        {
            if (chapter.Path.Length > 1)
            {
                // E.g. 15524
                var previousChapterPath = _chapterPathFilenames[chapter.Path.Substring(0, chapter.Path.Length - 1)];
                return $"This choice: <b>{chapter.SourceChoiceTitle}</b> <a href='{previousChapterPath}'>Go back</a>";
            }
            else
            {
                // E.g. 1
                return $"<a href='{STORY_HOMEPAGE_FILENAME}'>Go back</a>";
            }
        }

        private string GetChapterChoices(WdcStory story, WdcChapter chapter)
        {
            if (chapter.IsEnd || chapter.Choices.Count < 1)
            {
                // Is end
                return GetTemplate("ChapterChoiceEnd.html");
            }
            else
            {
                // There are choices
                var sbChapterChoices = new StringBuilder();
                foreach (var choice in chapter.Choices)
                {
                    // Does this choice lead to a valid chapter?
                    bool isChoiceValid = _chapterOutline.SingleOrDefault(c => c.Path == choice.PathLink) != null;

                    var choiceHtml = String.Empty;

                    // Choice links to a chapter that exists, choice is valid

                    if (isChoiceValid && _chapterPathFilenames != null)
                    {
                        choiceHtml = GetTemplate("ChapterChoiceItemValid.html")
                            .Replace("{ChoicePath}", choice.PathLink)
                            .Replace("{ChoiceLink}", _chapterPathFilenames[choice.PathLink])
                            .Replace("{ChoiceName}", choice.Name);
                    }
                    else
                    {
                        // Is either an invalid choice, or the path / filename lookup is missing (could be for a once-off chapter export)
                        choiceHtml = GetTemplate("ChapterChoiceItemInvalid.html")
                            .Replace("{ChoiceName}", choice.Name);
                    }

                    sbChapterChoices.AppendLine(choiceHtml);
                }

                return GetTemplate("ChapterChoiceList.html")
                    .Replace("{ChoiceList}", sbChapterChoices.ToString());
            }
        }

        private string GetPrettyChapterPath(string chapterPath)
        {
            if (string.IsNullOrWhiteSpace(chapterPath))
                return chapterPath;

            // Convert this: 12345
            // to this: 1-2-3-4-<b>#5</b>
            var sb = new StringBuilder();
            for (var i = 0; i < chapterPath.Length; i++)
            {
                if (i != (chapterPath.Length - 1))
                {
                    // if this is not the last character
                    sb.Append($"{chapterPath[i]}-");
                }
                else
                {
                    // If this is the last character
                    sb.Append($"<b>#{chapterPath[i]}</b>");
                }
            }

            return sb.ToString();
        }

        private string GetTemplate(string name)
        {
            return DataUtil.GetEmbeddedResource(HTML_TEMPLATE_ROOT + name);
        }

        private string GetPageTemplate(string title, string header, string content)
        {
            var html = GetTemplate("PageTemplate.html")
                .Replace("{PageHeader}", header)
                .Replace("{StyleData}", GetTemplate("Style.css"))
                .Replace("{DateTime}", DateTime.Now.ToString())
                .Replace("{PageTitle}", title)
                .Replace("{PageContent}", content);
            return html;
        }

        #region Filename generation functions

        public string GetHomepageFileName()
        {
            return STORY_HOMEPAGE_FILENAME;
        }

        public string GetOutlineFileName()
        {
            return STORY_OUTLINE_FILENAME;
        }

        public string GetRecentChaptersFileName()
        {
            return STORY_RECENT_CHAPTERS_FILENAME;
        }

        public string GetChapterFileName(string chapterPath)
        {
            //return string.Format(STORY_CHAPTER_FILENAME, chapterPath);
            return string.Format(STORY_CHAPTER_FILENAME, Guid.NewGuid().ToString("N"));
        }

        private bool IsChapterReady(WdcChapter chapter)
        {
            return chapter.LastSynced != DateTime.MinValue;
        }

        private bool IsChapterOutlineReady(WdcChapterOutline chapter)
        {
            return chapter.LastSynced != DateTime.MinValue;
        }

        #endregion
    }
}

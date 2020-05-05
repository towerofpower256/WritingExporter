using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WritingExporter.Common.Configuration;
using WritingExporter.Common.Data;
using WritingExporter.Common.Data.Repositories;
using WritingExporter.Common.Events;
using WritingExporter.Common.Events.WritingExporter.Common.Events;
using WritingExporter.Common.Logging;
using WritingExporter.Common.Models;
using WritingExporter.Common.WdcSync;
using WritingExporter.WinForms.Models;

namespace WritingExporter.WinForms.Forms
{
    // Play, stop, and other symbols from
    // https://www.w3schools.com/charsets/ref_utf_geometric.asp

    public partial class MainForm : Form, IEventSubscriber<RepositoryChangedEvent>, IEventSubscriber<WdcSyncStoryEvent>, IEventSubscriber<WdcSyncWorkerEvent>
    {
        EventHub _eventHub;
        WinFormsService _formService;
        WdcStoryRepository _storyRepo;
        WdcChapterRepository _chapterRepo;
        ConfigService _config;
        ILogger _log;
        bool _isReady = false; // Flag used in event handling. Don't want to handle events if the form isn't ready yet.

        public MainForm(ILoggerSource loggerSource, WinFormsService formsService, WdcStoryRepository storyRepo, WdcChapterRepository chapterRepo, ConfigService config, EventHub eventHub)
        {
            _log = loggerSource.GetLogger(typeof(MainForm));
            _config = config;
            _formService = formsService;
            _storyRepo = storyRepo;
            _chapterRepo = chapterRepo;
            _eventHub = eventHub;

            InitializeComponent();
        }

        public Task HandleEventAsync(RepositoryChangedEvent @event)
        {
            if (this.IsDisposed || this.Disposing) return Task.CompletedTask;
            // TODO handle cleaner. Would be better to just update that story instead of reloading the entire list.

            ReloadStories();

            return Task.CompletedTask;
        }

        public Task HandleEventAsync(WdcSyncStoryEvent @event)
        {
            if (this.IsDisposed || this.Disposing) return Task.CompletedTask;

            return Task.CompletedTask;
        }

        public Task HandleEventAsync(WdcSyncWorkerEvent @event)
        {
            if (this.IsDisposed || this.Disposing) return Task.CompletedTask;

            this.Invoke(new UpdateSyncWorkerInfoDelegate(UpdateSyncWorkerInfo), new object[]
            {
                @event.Status.State.ToString(),
                @event.Status.CurrentTask,
                @event.Status.Message
            });

            return Task.CompletedTask;
        }


        delegate void UpdateSyncWorkerInfoDelegate(string workerState, string workerCurrentTask, string workerMessage);
        void UpdateSyncWorkerInfo(string workerState, string workerCurrentTask, string workerMessage)
        {
            if (lblSyncWorkerState.InvokeRequired || lblSyncWorkerCurrentTask.InvokeRequired || lblSyncWorkerMessage.InvokeRequired)
            {
                this.Invoke(new UpdateSyncWorkerInfoDelegate(UpdateSyncWorkerInfo), new object[] { workerState, workerCurrentTask, workerMessage });
                return;
            }

            _log.Debug($"Updating sync worker info. {workerState} - {workerMessage}");

            lblSyncWorkerState.Text = workerState;
            lblSyncWorkerCurrentTask.Text = workerCurrentTask;
            lblSyncWorkerMessage.Text = workerMessage;
        }

        // Reload the stories data grid view
        delegate void ReloadStoriesDelegate();
        void ReloadStories()
        {
            if (dgvStories.InvokeRequired)
            {
                dgvStories.Invoke(new ReloadStoriesDelegate(ReloadStories));
                return;
            }

            // Update the DGV
            dgvStories.Rows.Clear();
            foreach (WdcStoryListViewModel storyVM in GetAllStories())
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvStories);
                UpdateDgvRowWithStoryInfo(newRow, storyVM);

                dgvStories.Rows.Add(newRow);
            }
        }

        void UpdateDgvRowWithStoryInfo(DataGridViewRow row, WdcStoryListViewModel storyVM)
        {
            row.Tag = storyVM.Story.SysId;
            row.Cells[0].Value = storyVM.Story.Name;
            row.Cells[1].Value = storyVM.StoryStateLabel;
            row.Cells[1].ToolTipText = storyVM.Story.StateMessage;
            row.Cells[2].Value = $"{storyVM.ChapterCountReady} / {storyVM.ChapterCountTotal}";
            row.Cells[3].Value = DgvDateTimeString(storyVM.Story.LastSynced);
            row.Cells[4].Value = DgvDateTimeString(storyVM.Story.LastUpdatedInfo);
            row.Cells[5].Value = DgvDateTimeString(storyVM.Story.LastUpdatedChapterOutline);
            row.Cells[6].Value = DgvDateTimeString(storyVM.RecentChapter);
        }

        void UpdateStoryInfo()
        {
            // Get the selected story ID
            if (dgvStories.SelectedRows.Count < 1)
            {
                txtStoryInfo.Clear();
                return;
            }

            var storyId = (string)dgvStories.SelectedRows[0].Tag;

            if (string.IsNullOrEmpty(storyId))
            {
                txtStoryInfo.Clear();
                return;
            }


            // Fetch the selected story
            var story = _storyRepo.GetByID(storyId);

            // Update the text box
            var sb = new StringBuilder();
            sb.AppendLine("Name:");
            sb.AppendLine(story.Name);
            sb.AppendLine();
            sb.AppendLine("Short description:");
            sb.AppendLine(story.ShortDescription);
            sb.AppendLine();
            sb.AppendLine("Description:");
            sb.AppendLine(story.Description);

            txtStoryInfo.Text = sb.ToString();
        }

        void OpenAddStoryDialog()
        {
            var form = _formService.GetForm<AddStoryForm>();
            form.ShowDialog(this);
        }

        void OpenSettingsDialog()
        {
            var form = _formService.GetForm<ConfigForm>();
            form.ShowDialog(this);
        }

        void StartSyncWorker()
        {
            _eventHub.PublishEvent(new WdcSyncWorkerCommandEvent(WdcSyncWorkerCommandEventType.StartWorker));
        }

        void StopSyncWorker()
        {
            _eventHub.PublishEvent(new WdcSyncWorkerCommandEvent(WdcSyncWorkerCommandEventType.StopWorker));
        }

        IEnumerable<WdcStoryListViewModel> GetAllStories()
        {
            // Timestamp
            var syncConfig = _config.GetSection<WdcSyncConfigSection>();
            DateTime timestamp = DateTime.Now - new TimeSpan(0, 0, 0, syncConfig.SyncChapterIntervalSeconds);

            // TODO Spruce up, I would rather not hit the database multiple times in short succession
            // Maybe a comprehensive query that'd grab as much informaiton as possible.
            var storyVMs = new List<WdcStoryListViewModel>();
            foreach (var story in _storyRepo.GetAll())
            {
                var vm = new WdcStoryListViewModel();
                vm.Story = story;
                vm.ChapterCountTotal = _chapterRepo.GetStoryChaptersCount(story.SysId);
                vm.ChapterCountReady = vm.ChapterCountTotal - _chapterRepo.GetStoryChapterNotSyncedSinceCount(story.SysId, timestamp);
                vm.RecentChapter = _chapterRepo.GetStoryLastUpdatedChaper(story.SysId);
                
                switch (story.State)
                {
                    case WdcStoryState.IdleItuPause:
                        vm.StoryStateLabel = "Paused-ITU";
                        break;
                    case WdcStoryState.Error:
                        vm.StoryStateLabel = "Disabled-Error";
                        break;
                    default:
                        vm.StoryStateLabel = story.State.ToString();
                        break;
                }
                storyVMs.Add(vm);
            }

            return storyVMs;
        }

        void ShowStoryContextMenu(Point pos, string storySysId)
        {
            _log.Debug($"Mouse pos: X {pos.X} Y {pos.Y}");

            WdcStory story = _storyRepo.GetByID(storySysId);
            if (story == null) return; // Something removed the story out from the users feet. Don't show context menu.

            var storyDisabled = story.State == WdcStoryState.Disabled || story.State == WdcStoryState.Error;

            var ctxMenu = new ContextMenu();

            ctxMenu.MenuItems.Add("Read story");
            ctxMenu.MenuItems.Add("Export story");
            ctxMenu.MenuItems.Add("-");
            if (storyDisabled)
                ctxMenu.MenuItems.Add("Enable story sync", new EventHandler((sender, args) => EnableStory(storySysId, true)));
            else
                ctxMenu.MenuItems.Add("Disable story sync", new EventHandler((sender, args) => EnableStory(storySysId, false)));
            ctxMenu.MenuItems.Add("-");
            ctxMenu.MenuItems.Add("Remove story", new EventHandler((sender, args) => RemoveStoryWithDialog(storySysId)));

            ctxMenu.Show(dgvStories, pos);
        }

        void RemoveStoryWithDialog(string storySysId)
        {
            if (MessageBox.Show("Are you sure that you want to remove this story?\nThis action cannot be undone.", 
                "Remove story confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveStory(storySysId);
            }
        }

        void RemoveStory(string storySysId)
        {
            _storyRepo.DeleteById(storySysId);
        }

        void EnableStory(string storySysId, bool enable)
        {
            var story = _storyRepo.GetByID(storySysId);
            if (story != null)
            {
                story.State = (enable ? WdcStoryState.Idle : WdcStoryState.Disabled);
                _storyRepo.Save(story);
            }
        }

        public static string DgvDateTimeString(DateTime dt)
        {
            if (dt == DateTime.MinValue)
            {
                return "Never";
            }
            else
            {
                return dt.ToString(CultureInfo.CurrentCulture);
            }
            
        }

        private void openWDCReaderTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var testerForm = _formService.GetForm<WdcReaderTesterForm>();
            testerForm.ShowDialog(this);
        }

        private void addStoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAddStoryDialog();
        }

        private void dgvStories_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStoryInfo();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettingsDialog();
        }

        private void btnSyncWorkerStart_Click(object sender, EventArgs e)
        {
            StartSyncWorker();
        }

        private void btnSyncWorkerStop_Click(object sender, EventArgs e)
        {
            StopSyncWorker();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _isReady = true;
            _eventHub.Subscribe<RepositoryChangedEvent>(this);
            _eventHub.Subscribe<WdcSyncStoryEvent>(this);
            _eventHub.Subscribe<WdcSyncWorkerEvent>(this);

            // Request that sync worker's current status
            _eventHub.PublishEvent(new WdcSyncWorkerCommandEvent(WdcSyncWorkerCommandEventType.RequestStatusUpdate));


            ReloadStories();
        }

        private void dgvStories_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && dgvStories.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvStories.SelectedRows[0];
                ShowStoryContextMenu(dgvStories.PointToClient(Cursor.Position), (string)selectedRow.Tag);
            }
        }
    }
}

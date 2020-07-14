using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WritingExporter.Common.Data.Repositories;

namespace WritingExporter.WinForms.Forms
{
    public partial class BrowseStoryForm : Form
    {
        const string TITLE_START = "Browse story";
        const string TEXT_STORY_INDEX = "-";
        const string TEXT_EMPTY = "(empty)";
        const string MSG_BAD_ID = "Error: invalid ID '{0}'";
        const string MSG_UNKNOWN_STORY = "Error: couldn't find a story with the SysId '{0}'";
        const string MSG_UNKNOWN_CHAPTER = "Error: couldn't find a chapter with the SysId '{0}'";
        const char ID_PREFIX_DELIM = ':';
        const char ID_PREFIX_STORY = 's';
        const char ID_PREFIX_CHAPTER = 'c';

        BindingSource _chapterBindingSource = new BindingSource();
        WdcStoryRepository _storyRepo;
        WdcChapterRepository _chapterRepo;
        string _storySysId = String.Empty;
        string _loadedId = String.Empty; // The ID of the info that's currently loaded in the text box

        public BrowseStoryForm(WdcStoryRepository storyRepo, WdcChapterRepository chapterRepo)
        {
            _storyRepo = storyRepo;
            _chapterRepo = chapterRepo;

            InitializeComponent();

            // Setup some stuff on the DGV
            dgvChapters.DataSource = _chapterBindingSource;
            dgvColumnIndex.DataPropertyName = "Index";
            dgvColumnTitle.DataPropertyName = "Title";
        }

        delegate void SetStoryDelegate(string storySysId);
        public void SetStory(string storySysId)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetStoryDelegate(SetStory), new { storySysId });
                return;
            }

            _storySysId = storySysId;
        }

        private void SetTitle(string text)
        {
            if (string.IsNullOrEmpty(text))
                this.Text = TITLE_START;
            else
                this.Text = $"{TITLE_START} - {text}";
        }

        private void ReloadChapters()
        {
            dgvChapters.Rows.Clear();

            if (string.IsNullOrEmpty(_storySysId))
                return;

            var story = _storyRepo.GetByID(_storySysId);

            if (story == null)
            {
                // TODO Handle missing story
                return;
            }

            // Add the story info
            SetTitle(story.Name);

            var dataTable = new DataTable();
            dataTable.Columns.Add("Index", typeof(string));
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Id", typeof(string));

            var storyInfoRow = dataTable.NewRow();
            storyInfoRow["Id"] = $"{ID_PREFIX_STORY}{ID_PREFIX_DELIM}{_storySysId}";
            storyInfoRow["Index"] = TEXT_STORY_INDEX;
            storyInfoRow["Title"] = StringOrEmpty(story.Name);
            dataTable.Rows.Add(storyInfoRow);

            // Add the chapters
            var chapters = _chapterRepo.GetStoryOutline(_storySysId);
            foreach (var c in chapters)
            {
                var chapterRow = dataTable.NewRow();

                chapterRow["Id"] = $"{ID_PREFIX_CHAPTER}{ID_PREFIX_DELIM}{c.SysId}";
                chapterRow["Index"] = c.Path;
                chapterRow["Title"] = StringOrEmpty(c.Title);

                dataTable.Rows.Add(chapterRow);
            }

            _chapterBindingSource.DataSource = dataTable;

            // Select the 1st row after loading
            dgvChapters.Rows[0].Selected = true;
        }

        private void LoadInfo(string target)
        {
            if (target == _loadedId)
                return; // What's wanting to be loaded is already showing. Do nothing.

            var targetSplit = target.Split(ID_PREFIX_DELIM);
            
            if (targetSplit.Length != 2)
            {
                txtInfo.Text = string.Format(MSG_BAD_ID, target);
            }

            if (targetSplit[0] == ID_PREFIX_STORY.ToString())
            {
                txtInfo.Text = LoadStoryInfo(targetSplit[1]);
            }
            else if (targetSplit[0] == ID_PREFIX_CHAPTER.ToString())
            {
                txtInfo.Text = LoadChapterInfo(targetSplit[1]);
            }
            else
            {
                txtInfo.Text = string.Format(MSG_BAD_ID, target);
            }
        }

        private string LoadStoryInfo(string storySysId)
        {
            var story = _storyRepo.GetByID(storySysId);

            if (story == null)
            {
                return string.Format(MSG_UNKNOWN_STORY, storySysId);
            }
            
            var sb = new StringBuilder();

            sb.AppendLine("Id:");
            sb.AppendLine(StringOrEmpty(story.Id));
            sb.AppendLine();
            sb.AppendLine("Name:");
            sb.AppendLine(StringOrEmpty(story.Name));
            sb.AppendLine();
            sb.AppendLine("Author:");
            sb.AppendLine($"{StringOrEmpty(story.AuthorName)} ({StringOrEmpty(story.AuthorUsername)})");
            sb.AppendLine();
            sb.AppendLine("First seen:");
            sb.AppendLine(StringOrEmpty(story.FirstSeen.ToString()));
            sb.AppendLine();
            sb.AppendLine("URL:");
            sb.AppendLine(StringOrEmpty(story.Url));
            sb.AppendLine();
            sb.AppendLine("Short description:");
            sb.AppendLine(StringOrEmpty(story.ShortDescription));
            sb.AppendLine();
            sb.AppendLine("Description:");
            sb.AppendLine(StringOrEmpty(story.Description));

            return sb.ToString();
        }

        private string LoadChapterInfo(string chapterSysId)
        {
            var chapter = _chapterRepo.GetByID(chapterSysId);

            if (chapter == null)
            {
                return string.Format(MSG_UNKNOWN_CHAPTER, chapterSysId);
            }

            var sb = new StringBuilder();

            sb.AppendLine("Path:");
            sb.AppendLine(StringOrEmpty(chapter.Path));
            sb.AppendLine();
            sb.AppendLine("Title:");
            sb.AppendLine(StringOrEmpty(chapter.Title));
            sb.AppendLine();
            sb.AppendLine("Source choice:");
            sb.AppendLine(StringOrEmpty(chapter.SourceChoiceTitle));
            sb.AppendLine();
            sb.AppendLine("Author:");
            sb.AppendLine($"{StringOrEmpty(chapter.AuthorName)} ({StringOrEmpty(chapter.AuthorUsername)})");
            sb.AppendLine();
            sb.AppendLine("First seen:");
            sb.AppendLine(StringOrEmpty(chapter.FirstSeen.ToString()));
            sb.AppendLine();
            sb.AppendLine("Content:");
            sb.AppendLine(StringOrEmpty(chapter.Content));
            sb.AppendLine();
            sb.AppendLine("Choices:");
            foreach (var choice in chapter.Choices)
            {
                sb.AppendLine($"{StringOrEmpty(choice.Name)} ({choice.PathLink})");
            }

            return sb.ToString();
        }

        private string StringOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input) ? TEXT_EMPTY : input;
        }

        private void BrowseStoryForm_Load(object sender, EventArgs e)
        {
            // If the story sys_id has been provided, load it
            if (!string.IsNullOrEmpty(_storySysId))
                ReloadChapters();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReloadChapters();
        }

        private void dgvChapters_SelectionChanged(object sender, EventArgs e)
        {
            // Get the currently selected row
            var dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count == 0) return; // Don't do anthing if no row is selected
            var currentRow = ((DataGridView)sender).SelectedRows[0];

            string id = ((DataRowView)currentRow.DataBoundItem)["Id"] as string;
            LoadInfo(id);
        }
    }
}

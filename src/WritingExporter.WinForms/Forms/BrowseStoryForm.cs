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


        WdcStoryRepository _storyRepo;
        WdcChapterRepository _chapterRepo;
        string _storySysId = String.Empty;

        public BrowseStoryForm(WdcStoryRepository storyRepo, WdcChapterRepository chapterRepo)
        {
            _storyRepo = storyRepo;
            _chapterRepo = chapterRepo;

            InitializeComponent();
        }

        private void SetStory(string storySysId)
        {
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

            var storyInfoRow = new DataGridViewRow();
            storyInfoRow.Tag = $"{ID_PREFIX_STORY}{ID_PREFIX_DELIM}{_storySysId}";
            storyInfoRow.Cells.Add(new DataGridViewTextBoxCell() { Value = TEXT_STORY_INDEX });
            storyInfoRow.Cells.Add(new DataGridViewTextBoxCell() { Value = StringOrEmpty(story.Name) });

            dgvChapters.Rows.Add(storyInfoRow);

            // Add the chapters
            var chapters = _chapterRepo.GetStoryOutline(_storySysId);
            foreach (var c in chapters)
            {
                var chapterRow = new DataGridViewRow();

                chapterRow.Tag = $"{ID_PREFIX_CHAPTER}{ID_PREFIX_DELIM}{c.SysId}";
                chapterRow.Cells.Add(new DataGridViewTextBoxCell() { Value = c.Path });
                chapterRow.Cells.Add(new DataGridViewTextBoxCell() { Value = StringOrEmpty(c.Title) });

                dgvChapters.Rows.Add(chapterRow);
            }
        }

        private void LoadInfo(string target)
        {
            var targetSplit = target.Split(ID_PREFIX_DELIM);
            
            if (targetSplit.Length != 2)
            {
                txtInfo.Text = string.Format(MSG_BAD_ID, target);
            }

            if (targetSplit[0] == ID_PREFIX_STORY.ToString())
            {
                LoadStoryInfo(targetSplit[1]);
            }
            else if (targetSplit[0] == ID_PREFIX_CHAPTER.ToString())
            {
                LoadChapterInfo(targetSplit[1]);
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
            sb.AppendLine(story.Id);
            sb.AppendLine();
            sb.AppendLine("Name:");
            sb.AppendLine(story.Name);
            sb.AppendLine();
            sb.AppendLine("Author:");
            sb.AppendLine($"{story.AuthorName} ({story.AuthorUsername})");
            sb.AppendLine();
            sb.AppendLine("First seen:");
            sb.AppendLine(story.FirstSeen.ToString());
            sb.AppendLine();
            sb.AppendLine("URL:");
            sb.AppendLine(story.Url);
            sb.AppendLine();
            sb.AppendLine("Short description:");
            sb.AppendLine(story.ShortDescription);
            sb.AppendLine();
            sb.AppendLine("Description:");
            sb.AppendLine(story.Description);

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
            sb.AppendLine(chapter.Path);
            sb.AppendLine();
            sb.AppendLine("Title:");
            sb.AppendLine(chapter.Title);
            sb.AppendLine();
            sb.AppendLine("Source choice:");
            sb.AppendLine(chapter.SourceChoiceTitle);
            sb.AppendLine();
            sb.AppendLine("Author:");
            sb.AppendLine($"{chapter.AuthorName} ({chapter.AuthorUsername})");
            sb.AppendLine();
            sb.AppendLine("First seen:");
            sb.AppendLine(chapter.FirstSeen.ToString());
            sb.AppendLine();
            sb.AppendLine("Content:");
            sb.AppendLine(chapter.Content);
            sb.AppendLine();
            sb.AppendLine("Choices:");
            foreach (var choice in chapter.Choices)
            {
                sb.AppendLine($"{choice.Name} ({choice.PathLink})");
            }

            return sb.ToString();
        }

        private string StringOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input) ? TEXT_EMPTY : input;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WritingExporter.Common.Logging;
using WritingExporter.Common.WDC;

namespace WritingExporter.WinForms.WdcTester.Forms
{
    public partial class MainForm : Form
    {
        ILoggerSource _logSource;
        ILogger _log;

        public MainForm(ILoggerSource logSource)
        {
            _logSource = logSource;
            _log = logSource.GetLogger(typeof(MainForm));

            InitializeComponent();

            // Load the default WDC reader options
            ImportWdcReaderOptions(new WdcReaderOptions());
        }

        private void ImportWdcReaderOptions(WdcReaderOptions _options)
        {
            fieldInteractiveTitleRegex.Text = _options.InteractiveTitleRegex;
            fieldInteractiveShortDescriptionRegex.Text = _options.InteractiveShortDescriptionRegex;
            fieldInteractiveDescriptionRegex.Text = _options.InteractiveDescriptionRegex;
            fieldChapterAuthorChunkRegex.Text = _options.ChapterAuthorChunkRegex;
            fieldChapterAuthorNameRegex.Text = _options.ChapterAuthorNameRegex;
            fieldChapterAuthorUsernameRegex.Text = _options.ChapterAuthorUsernameRegex;
            fieldChapterChoicesChunkRegex.Text = _options.ChapterChoicesChunkRegex;
            fieldChapterChoicesRegex.Text = _options.ChapterChoicesRegex;
            fieldChapterChoiceUrlRegex.Text = _options.ChapterChoiceUrlRegex;
            fieldChapterContentRegex.Text = _options.ChapterContentRegex;
            fieldChapterEndCheckRegex.Text = _options.ChapterEndCheckRegex;
            fieldChapterSourceChoiceRegex.Text = _options.ChapterSourceChoiceRegex;
            fieldChapterTitleRegex.Text = _options.ChapterTitleRegex;
        }

        private WdcReaderOptions ExportWdcReaderOptions()
        {
            var options = new WdcReaderOptions();

            options.InteractiveTitleRegex = fieldInteractiveTitleRegex.Text;
            options.InteractiveShortDescriptionRegex = fieldInteractiveShortDescriptionRegex.Text;
            options.InteractiveDescriptionRegex = fieldInteractiveDescriptionRegex.Text;
            options.ChapterAuthorChunkRegex = fieldChapterAuthorChunkRegex.Text;
            options.ChapterAuthorNameRegex = fieldChapterAuthorNameRegex.Text;
            options.ChapterAuthorUsernameRegex = fieldChapterAuthorUsernameRegex.Text;
            options.ChapterChoicesChunkRegex = fieldChapterChoicesChunkRegex.Text;
            options.ChapterChoicesRegex = fieldChapterChoicesRegex.Text;
            options.ChapterChoiceUrlRegex = fieldChapterChoiceUrlRegex.Text;
            options.ChapterContentRegex = fieldChapterContentRegex.Text;
            options.ChapterEndCheckRegex = fieldChapterEndCheckRegex.Text;
            options.ChapterSourceChoiceRegex = fieldChapterSourceChoiceRegex.Text;
            options.ChapterTitleRegex = fieldChapterTitleRegex.Text;

            return options;
        }

        private void ReadStory()
        {
            var sb = new StringBuilder();
            var options = ExportWdcReaderOptions();
            var reader = new WdcReader(_logSource, options);
            var payload = new WdcPayload("TEST", txtContentInput.Text);

            RunTest(sb, "read story title", 
                () => sb.AppendLine($"Story title: {reader.GetInteractiveStoryTitle(payload)}"));

            RunTest(sb, "read story username", () =>
            {
                var author = reader.GetInteractiveStoryAuthor(payload);
                sb.AppendLine($"Story author name: {author.Name}");
                sb.AppendLine($"Story author username: {author.Username}");
            });

            RunTest(sb, "read story short description",
                () => sb.AppendLine($"Story short description: {reader.GetInteractiveStoryShortDescription(payload)}"));

            RunTest(sb, "read story description",
                () => sb.AppendLine($"Story description: {reader.GetInteractiveStoryDescription(payload)}"));

            txtOutput.Text = sb.ToString();
        }

        private void ReadChapter()
        {
            var sb = new StringBuilder();
            var options = ExportWdcReaderOptions();
            var reader = new WdcReader(_logSource, options);
            var payload = new WdcPayload("TEST", txtContentInput.Text);

            RunTest(sb, "read chapter title",
                () => sb.AppendLine($"Chapter title: {reader.GetInteractiveChapterTitle(payload)}"));

            RunTest(sb, "read chapter author", () =>
            {
                var author = reader.GetInteractiveChapterAuthor(payload);
                sb.AppendLine($"Chapter author name: {author.Name}");
                sb.AppendLine($"Chapter author username: {author.Username}");
            });

            RunTest(sb, "read chapter source choice",
                () => sb.AppendLine($"Chapter short description: {reader.GetInteractiveChapterSourceChoice(payload)}"));

            RunTest(sb, "read chapter choices", () => {
                sb.AppendLine($"Chapter choices:");
                var choices = reader.GetInteractiveChapterChoices(payload);
                foreach (var choice in choices)
                {
                    sb.AppendLine($"Path: {choice.PathLink} Name: {choice.Name}");
                }
            });

            RunTest(sb, "read chapter content",
                () => sb.AppendLine($"Chapter description: {reader.GetInteractiveChapterContent(payload)}"));

            txtOutput.Text = sb.ToString();
        }

        private void RunTest(StringBuilder sb, string actionDesc, Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                sb.AppendLine($"Exception trying to {actionDesc}.");
                sb.AppendLine(ex.GetType().ToString());
                sb.AppendLine(ex.Message);
            }
            finally
            {
                sb.AppendLine();
            }
        }

        private void btnReadStory_Click(object sender, EventArgs e)
        {
            ReadStory();
        }

        private void btnReadChapter_Click(object sender, EventArgs e)
        {
            ReadChapter();
        }
    }
}

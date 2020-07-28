﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WritingExporter.Common.Wdc;
using WritingExporter.Common.Configuration;

namespace WritingExporter.WinForms.Forms
{
    public partial class WdcReaderTesterForm : Form
    {
        ConfigService _config;
        bool _hasChanged = false;

        public WdcReaderTesterForm(ConfigService config)
        {
            _config = config;

            InitializeComponent();

            LoadSettings();
        }

        private void LoadSettings()
        {
            // TODO fetch from options. For now, just load default.
            LoadSettings(_config.GetSection<WdcReaderConfigSection>().ReaderOptions);
        }

        private void LoadDefaultSettings()
        {
            LoadSettings(new WdcReaderOptions());
        }

        private delegate void LoadSettingsDelegate(WdcReaderOptions readerOptions);
        private void LoadSettings(WdcReaderOptions readerOptions)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new LoadSettingsDelegate(LoadSettings), new { readerOptions });
                return;
            }

            fieldInteractiveTitleRegex.Text = readerOptions.InteractiveTitleRegex;
            fieldInteractiveShortDescriptionRegex.Text = readerOptions.InteractiveShortDescriptionRegex;
            fieldInteractiveDescriptionRegex.Text = readerOptions.InteractiveDescriptionRegex;
            fieldChapterAuthorChunkRegex.Text = readerOptions.ChapterAuthorChunkRegex;
            fieldChapterAuthorNameRegex.Text = readerOptions.ChapterAuthorNameRegex;
            fieldChapterAuthorUsernameRegex.Text = readerOptions.ChapterAuthorUsernameRegex;
            fieldChapterChoicesChunkRegex.Text = readerOptions.ChapterChoicesChunkRegex;
            fieldChapterChoicesRegex.Text = readerOptions.ChapterChoicesRegex;
            fieldChapterChoiceUrlRegex.Text = readerOptions.ChapterChoiceUrlRegex;
            fieldChapterContentRegex.Text = readerOptions.ChapterContentRegex;
            fieldChapterEndCheckRegex.Text = readerOptions.ChapterEndCheckRegex;
            fieldChapterSourceChoiceRegex.Text = readerOptions.ChapterSourceChoiceRegex;
            fieldChapterTitleRegex.Text = readerOptions.ChapterTitleRegex;
        }

        private WdcReaderOptions ExportWdcReaderOptions()
        {
            var readerOptions = new WdcReaderOptions();

            readerOptions.InteractiveTitleRegex = fieldInteractiveTitleRegex.Text;
            readerOptions.InteractiveShortDescriptionRegex = fieldInteractiveShortDescriptionRegex.Text;
            readerOptions.InteractiveDescriptionRegex = fieldInteractiveDescriptionRegex.Text;
            readerOptions.ChapterAuthorChunkRegex = fieldChapterAuthorChunkRegex.Text;
            readerOptions.ChapterAuthorNameRegex = fieldChapterAuthorNameRegex.Text;
            readerOptions.ChapterAuthorUsernameRegex = fieldChapterAuthorUsernameRegex.Text;
            readerOptions.ChapterChoicesChunkRegex = fieldChapterChoicesChunkRegex.Text;
            readerOptions.ChapterChoicesRegex = fieldChapterChoicesRegex.Text;
            readerOptions.ChapterChoiceUrlRegex = fieldChapterChoiceUrlRegex.Text;
            readerOptions.ChapterContentRegex = fieldChapterContentRegex.Text;
            readerOptions.ChapterEndCheckRegex = fieldChapterEndCheckRegex.Text;
            readerOptions.ChapterSourceChoiceRegex = fieldChapterSourceChoiceRegex.Text;
            readerOptions.ChapterTitleRegex = fieldChapterTitleRegex.Text;

            return readerOptions;
        }

        private void SaveSettings()
        {
            _config.SetSection(new WdcReaderConfigSection() { ReaderOptions = ExportWdcReaderOptions() });
            _config.SaveSettings();
        }

        private void ReadStory()
        {
            var sb = new StringBuilder();
            var options = ExportWdcReaderOptions();
            var reader = new WdcReader(options);
            var payload = txtContentInput.Text;

            RunTest(sb, "read story title",
                () => sb.AppendLine($"Story title: {reader.GetInteractiveStoryTitle(payload)}"));

            RunTest(sb, "read story username", () =>
            {
                var author = reader.GetInteractiveStoryAuthor(payload);
                sb.AppendLine("Story author:");
                sb.AppendLine($"Name: {author.AuthorName}");
                sb.AppendLine($"Username: {author.AuthorUsername}");
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
            var reader = new WdcReader(options);
            var payload = txtContentInput.Text;

            RunTest(sb, "read chapter title",
                () => sb.AppendLine($"Chapter title: {reader.GetInteractiveChapterTitle(payload)}"));

            RunTest(sb, "read chapter author", () =>
            {
                var author = reader.GetInteractiveChapterAuthor(payload);
                sb.AppendLine($"Chapter author");
                sb.AppendLine($"Name: {author.AuthorName}");
                sb.AppendLine($"Username: {author.AuthorUsername}");
            });

            RunTest(sb, "read chapter source choice",
                () => sb.AppendLine($"Chapter short description: {reader.GetInteractiveChapterSourceChoice(payload)}"));

            RunTest(sb, "read chapter choices", () => {
                sb.AppendLine($"Chapter choices:");
                if (reader.IsInteractiveChapterEnd(payload))
                {
                    sb.AppendLine("This chapter is an end chapter");
                }
                else
                {
                    var choices = reader.GetInteractiveChapterChoices(payload);
                    foreach (var choice in choices)
                    {
                        sb.AppendLine($"Path: {choice.PathLink} Name: {choice.Name}");
                    }
                }
            });

            RunTest(sb, "read chapter content",
                () => sb.AppendLine($"Chapter description: {reader.GetInteractiveChapterContent(payload)}"));

            txtOutput.Text = sb.ToString();
        }

        private void ReadChapterMap()
        {
            //throw new NotImplementedException();

            var sb = new StringBuilder();
            var options = ExportWdcReaderOptions();
            var reader = new WdcReader(options);
            var payload = txtContentInput.Text;

            RunTest(sb, "read chapter map",
                () => {
                    var map = reader.GetInteractiveChapterList(string.Empty, txtContentInput.Text);

                    sb.AppendLine($"Chapter map, {map.Count()} results:");
                    

                    foreach (var c in map)
                    {
                        sb.AppendLine(c.ToString());
                        sb.AppendLine();
                    }
                });

            txtOutput.Text = sb.ToString();
        }

        private void RunTest(StringBuilder sb, string actionDesc, Action action)
        {
            sb.AppendLine("=========================");
            sb.Append("== ");
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

        private void btnReadChapterMap_Click(object sender, EventArgs e)
        {
            ReadChapterMap();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // TODO check for changes and warn user about losing unsaved changes

            this.Close();
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnLoadDefaults_Click(object sender, EventArgs e)
        {
            LoadDefaultSettings();
        }
    }
}

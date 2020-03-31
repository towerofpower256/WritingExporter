namespace WritingExporter.WinForms.Forms
{
    partial class WdcReaderTesterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtContentInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.tableLayoutStoryFields = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlModeSelect = new System.Windows.Forms.TabControl();
            this.tabPageStory = new System.Windows.Forms.TabPage();
            this.tabPageChapterMap = new System.Windows.Forms.TabPage();
            this.tabPageChapter = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReadStory = new System.Windows.Forms.Button();
            this.tableLayoutStory = new System.Windows.Forms.TableLayoutPanel();
            this.panelStoryFields = new System.Windows.Forms.Panel();
            this.tableLayoutFormWrapper = new System.Windows.Forms.TableLayoutPanel();
            this.gbInputContent = new System.Windows.Forms.GroupBox();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.tableLayoutChapter = new System.Windows.Forms.TableLayoutPanel();
            this.btnReadChapter = new System.Windows.Forms.Button();
            this.panelChapterFields = new System.Windows.Forms.Panel();
            this.tableLayoutChapterFields = new System.Windows.Forms.TableLayoutPanel();
            this.btnReadChapterMap = new System.Windows.Forms.Button();
            this.fieldInteractiveDescriptionRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldInteractiveTitleRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldInteractiveShortDescriptionRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldChapterAuthorNameRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldChapterAuthorUsernameRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldChapterAuthorChunkRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldChapterContentRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldChapterSourceChoiceRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldChapterTitleRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldChapterChoicesChunkRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldChapterChoicesRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldChapterChoiceUrlRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.fieldChapterEndCheckRegex = new WritingExporter.WinForms.Controls.WdcTesterOptionControl();
            this.tableLayoutStoryFields.SuspendLayout();
            this.tabControlModeSelect.SuspendLayout();
            this.tabPageStory.SuspendLayout();
            this.tabPageChapterMap.SuspendLayout();
            this.tabPageChapter.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutStory.SuspendLayout();
            this.panelStoryFields.SuspendLayout();
            this.tableLayoutFormWrapper.SuspendLayout();
            this.gbInputContent.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.tableLayoutChapter.SuspendLayout();
            this.panelChapterFields.SuspendLayout();
            this.tableLayoutChapterFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtContentInput
            // 
            this.txtContentInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContentInput.Location = new System.Drawing.Point(3, 16);
            this.txtContentInput.MaxLength = 0;
            this.txtContentInput.Multiline = true;
            this.txtContentInput.Name = "txtContentInput";
            this.txtContentInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContentInput.Size = new System.Drawing.Size(337, 541);
            this.txtContentInput.TabIndex = 0;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 16);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(338, 541);
            this.txtOutput.TabIndex = 1;
            // 
            // tableLayoutStoryFields
            // 
            this.tableLayoutStoryFields.AutoSize = true;
            this.tableLayoutStoryFields.ColumnCount = 1;
            this.tableLayoutStoryFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutStoryFields.Controls.Add(this.fieldInteractiveDescriptionRegex, 0, 2);
            this.tableLayoutStoryFields.Controls.Add(this.fieldInteractiveTitleRegex, 0, 0);
            this.tableLayoutStoryFields.Controls.Add(this.fieldInteractiveShortDescriptionRegex, 0, 1);
            this.tableLayoutStoryFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutStoryFields.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutStoryFields.Name = "tableLayoutStoryFields";
            this.tableLayoutStoryFields.RowCount = 4;
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStoryFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStoryFields.Size = new System.Drawing.Size(317, 180);
            this.tableLayoutStoryFields.TabIndex = 2;
            // 
            // tabControlModeSelect
            // 
            this.tabControlModeSelect.Controls.Add(this.tabPageStory);
            this.tabControlModeSelect.Controls.Add(this.tabPageChapterMap);
            this.tabControlModeSelect.Controls.Add(this.tabPageChapter);
            this.tabControlModeSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlModeSelect.Location = new System.Drawing.Point(3, 16);
            this.tabControlModeSelect.Name = "tabControlModeSelect";
            this.tabControlModeSelect.SelectedIndex = 0;
            this.tabControlModeSelect.Size = new System.Drawing.Size(337, 541);
            this.tabControlModeSelect.TabIndex = 3;
            // 
            // tabPageStory
            // 
            this.tabPageStory.AutoScroll = true;
            this.tabPageStory.Controls.Add(this.tableLayoutStory);
            this.tabPageStory.Location = new System.Drawing.Point(4, 22);
            this.tabPageStory.Name = "tabPageStory";
            this.tabPageStory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStory.Size = new System.Drawing.Size(329, 515);
            this.tabPageStory.TabIndex = 0;
            this.tabPageStory.Text = "Story";
            this.tabPageStory.UseVisualStyleBackColor = true;
            // 
            // tabPageChapterMap
            // 
            this.tabPageChapterMap.Controls.Add(this.btnReadChapterMap);
            this.tabPageChapterMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageChapterMap.Name = "tabPageChapterMap";
            this.tabPageChapterMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChapterMap.Size = new System.Drawing.Size(329, 515);
            this.tabPageChapterMap.TabIndex = 1;
            this.tabPageChapterMap.Text = "Map";
            this.tabPageChapterMap.UseVisualStyleBackColor = true;
            // 
            // tabPageChapter
            // 
            this.tabPageChapter.Controls.Add(this.tableLayoutChapter);
            this.tabPageChapter.Location = new System.Drawing.Point(4, 22);
            this.tabPageChapter.Name = "tabPageChapter";
            this.tabPageChapter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChapter.Size = new System.Drawing.Size(329, 515);
            this.tabPageChapter.TabIndex = 2;
            this.tabPageChapter.Text = "Chapter";
            this.tabPageChapter.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1048, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // btnReadStory
            // 
            this.btnReadStory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReadStory.Location = new System.Drawing.Point(3, 3);
            this.btnReadStory.Name = "btnReadStory";
            this.btnReadStory.Size = new System.Drawing.Size(317, 24);
            this.btnReadStory.TabIndex = 0;
            this.btnReadStory.Text = "Read story info";
            this.btnReadStory.UseVisualStyleBackColor = true;
            this.btnReadStory.Click += new System.EventHandler(this.btnReadStory_Click);
            // 
            // tableLayoutStory
            // 
            this.tableLayoutStory.ColumnCount = 1;
            this.tableLayoutStory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutStory.Controls.Add(this.btnReadStory, 0, 0);
            this.tableLayoutStory.Controls.Add(this.panelStoryFields, 0, 1);
            this.tableLayoutStory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutStory.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutStory.Name = "tableLayoutStory";
            this.tableLayoutStory.RowCount = 2;
            this.tableLayoutStory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutStory.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutStory.Size = new System.Drawing.Size(323, 509);
            this.tableLayoutStory.TabIndex = 5;
            // 
            // panelStoryFields
            // 
            this.panelStoryFields.AutoScroll = true;
            this.panelStoryFields.Controls.Add(this.tableLayoutStoryFields);
            this.panelStoryFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStoryFields.Location = new System.Drawing.Point(3, 33);
            this.panelStoryFields.Name = "panelStoryFields";
            this.panelStoryFields.Size = new System.Drawing.Size(317, 473);
            this.panelStoryFields.TabIndex = 1;
            // 
            // tableLayoutFormWrapper
            // 
            this.tableLayoutFormWrapper.ColumnCount = 3;
            this.tableLayoutFormWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutFormWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutFormWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutFormWrapper.Controls.Add(this.gbOutput, 2, 0);
            this.tableLayoutFormWrapper.Controls.Add(this.gbInputContent, 0, 0);
            this.tableLayoutFormWrapper.Controls.Add(this.gbOptions, 1, 0);
            this.tableLayoutFormWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutFormWrapper.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutFormWrapper.Name = "tableLayoutFormWrapper";
            this.tableLayoutFormWrapper.RowCount = 1;
            this.tableLayoutFormWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFormWrapper.Size = new System.Drawing.Size(1048, 566);
            this.tableLayoutFormWrapper.TabIndex = 5;
            // 
            // gbInputContent
            // 
            this.gbInputContent.Controls.Add(this.txtContentInput);
            this.gbInputContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInputContent.Location = new System.Drawing.Point(3, 3);
            this.gbInputContent.Name = "gbInputContent";
            this.gbInputContent.Size = new System.Drawing.Size(343, 560);
            this.gbInputContent.TabIndex = 0;
            this.gbInputContent.TabStop = false;
            this.gbInputContent.Text = "HTML Content";
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.tabControlModeSelect);
            this.gbOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOptions.Location = new System.Drawing.Point(352, 3);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(343, 560);
            this.gbOptions.TabIndex = 1;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.txtOutput);
            this.gbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOutput.Location = new System.Drawing.Point(701, 3);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(344, 560);
            this.gbOutput.TabIndex = 6;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Results";
            // 
            // tableLayoutChapter
            // 
            this.tableLayoutChapter.ColumnCount = 1;
            this.tableLayoutChapter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutChapter.Controls.Add(this.btnReadChapter, 0, 0);
            this.tableLayoutChapter.Controls.Add(this.panelChapterFields, 0, 1);
            this.tableLayoutChapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutChapter.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutChapter.Name = "tableLayoutChapter";
            this.tableLayoutChapter.RowCount = 2;
            this.tableLayoutChapter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutChapter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapter.Size = new System.Drawing.Size(323, 509);
            this.tableLayoutChapter.TabIndex = 0;
            // 
            // btnReadChapter
            // 
            this.btnReadChapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReadChapter.Location = new System.Drawing.Point(3, 3);
            this.btnReadChapter.Name = "btnReadChapter";
            this.btnReadChapter.Size = new System.Drawing.Size(317, 24);
            this.btnReadChapter.TabIndex = 0;
            this.btnReadChapter.Text = "Read chapter";
            this.btnReadChapter.UseVisualStyleBackColor = true;
            this.btnReadChapter.Click += new System.EventHandler(this.btnReadChapter_Click);
            // 
            // panelChapterFields
            // 
            this.panelChapterFields.AutoScroll = true;
            this.panelChapterFields.Controls.Add(this.tableLayoutChapterFields);
            this.panelChapterFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChapterFields.Location = new System.Drawing.Point(3, 33);
            this.panelChapterFields.Name = "panelChapterFields";
            this.panelChapterFields.Size = new System.Drawing.Size(317, 473);
            this.panelChapterFields.TabIndex = 1;
            // 
            // tableLayoutChapterFields
            // 
            this.tableLayoutChapterFields.AutoScroll = true;
            this.tableLayoutChapterFields.ColumnCount = 1;
            this.tableLayoutChapterFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutChapterFields.Controls.Add(this.fieldChapterAuthorNameRegex, 0, 5);
            this.tableLayoutChapterFields.Controls.Add(this.fieldChapterAuthorUsernameRegex, 0, 4);
            this.tableLayoutChapterFields.Controls.Add(this.fieldChapterAuthorChunkRegex, 0, 3);
            this.tableLayoutChapterFields.Controls.Add(this.fieldChapterContentRegex, 0, 2);
            this.tableLayoutChapterFields.Controls.Add(this.fieldChapterSourceChoiceRegex, 0, 1);
            this.tableLayoutChapterFields.Controls.Add(this.fieldChapterTitleRegex, 0, 0);
            this.tableLayoutChapterFields.Controls.Add(this.fieldChapterChoicesChunkRegex, 0, 6);
            this.tableLayoutChapterFields.Controls.Add(this.fieldChapterChoicesRegex, 0, 7);
            this.tableLayoutChapterFields.Controls.Add(this.fieldChapterChoiceUrlRegex, 0, 8);
            this.tableLayoutChapterFields.Controls.Add(this.fieldChapterEndCheckRegex, 0, 10);
            this.tableLayoutChapterFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutChapterFields.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutChapterFields.Name = "tableLayoutChapterFields";
            this.tableLayoutChapterFields.RowCount = 11;
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutChapterFields.Size = new System.Drawing.Size(317, 473);
            this.tableLayoutChapterFields.TabIndex = 6;
            // 
            // btnReadChapterMap
            // 
            this.btnReadChapterMap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReadChapterMap.Location = new System.Drawing.Point(3, 3);
            this.btnReadChapterMap.Name = "btnReadChapterMap";
            this.btnReadChapterMap.Size = new System.Drawing.Size(323, 25);
            this.btnReadChapterMap.TabIndex = 0;
            this.btnReadChapterMap.Text = "Read chapter map";
            this.btnReadChapterMap.UseVisualStyleBackColor = true;
            this.btnReadChapterMap.Click += new System.EventHandler(this.btnReadChapterMap_Click);
            // 
            // fieldInteractiveDescriptionRegex
            // 
            this.fieldInteractiveDescriptionRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldInteractiveDescriptionRegex.Label = "InteractiveDescriptionRegex";
            this.fieldInteractiveDescriptionRegex.Location = new System.Drawing.Point(3, 123);
            this.fieldInteractiveDescriptionRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldInteractiveDescriptionRegex.Name = "fieldInteractiveDescriptionRegex";
            this.fieldInteractiveDescriptionRegex.Size = new System.Drawing.Size(311, 54);
            this.fieldInteractiveDescriptionRegex.TabIndex = 6;
            // 
            // fieldInteractiveTitleRegex
            // 
            this.fieldInteractiveTitleRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldInteractiveTitleRegex.Label = "InteractiveTitleRegex";
            this.fieldInteractiveTitleRegex.Location = new System.Drawing.Point(3, 3);
            this.fieldInteractiveTitleRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldInteractiveTitleRegex.Name = "fieldInteractiveTitleRegex";
            this.fieldInteractiveTitleRegex.Size = new System.Drawing.Size(311, 54);
            this.fieldInteractiveTitleRegex.TabIndex = 1;
            // 
            // fieldInteractiveShortDescriptionRegex
            // 
            this.fieldInteractiveShortDescriptionRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldInteractiveShortDescriptionRegex.Label = "InteractiveShortDescriptionRegex";
            this.fieldInteractiveShortDescriptionRegex.Location = new System.Drawing.Point(3, 63);
            this.fieldInteractiveShortDescriptionRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldInteractiveShortDescriptionRegex.Name = "fieldInteractiveShortDescriptionRegex";
            this.fieldInteractiveShortDescriptionRegex.Size = new System.Drawing.Size(311, 54);
            this.fieldInteractiveShortDescriptionRegex.TabIndex = 5;
            // 
            // fieldChapterAuthorNameRegex
            // 
            this.fieldChapterAuthorNameRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterAuthorNameRegex.Label = "ChapterAuthorNameRegex";
            this.fieldChapterAuthorNameRegex.Location = new System.Drawing.Point(3, 303);
            this.fieldChapterAuthorNameRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterAuthorNameRegex.Name = "fieldChapterAuthorNameRegex";
            this.fieldChapterAuthorNameRegex.Size = new System.Drawing.Size(294, 54);
            this.fieldChapterAuthorNameRegex.TabIndex = 5;
            // 
            // fieldChapterAuthorUsernameRegex
            // 
            this.fieldChapterAuthorUsernameRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterAuthorUsernameRegex.Label = "ChapterAuthorUsernameRegex";
            this.fieldChapterAuthorUsernameRegex.Location = new System.Drawing.Point(3, 243);
            this.fieldChapterAuthorUsernameRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterAuthorUsernameRegex.Name = "fieldChapterAuthorUsernameRegex";
            this.fieldChapterAuthorUsernameRegex.Size = new System.Drawing.Size(294, 54);
            this.fieldChapterAuthorUsernameRegex.TabIndex = 4;
            // 
            // fieldChapterAuthorChunkRegex
            // 
            this.fieldChapterAuthorChunkRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterAuthorChunkRegex.Label = "ChapterAuthorChunkRegex";
            this.fieldChapterAuthorChunkRegex.Location = new System.Drawing.Point(3, 183);
            this.fieldChapterAuthorChunkRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterAuthorChunkRegex.Name = "fieldChapterAuthorChunkRegex";
            this.fieldChapterAuthorChunkRegex.Size = new System.Drawing.Size(294, 54);
            this.fieldChapterAuthorChunkRegex.TabIndex = 3;
            // 
            // fieldChapterContentRegex
            // 
            this.fieldChapterContentRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterContentRegex.Label = "ChapterContentRegex";
            this.fieldChapterContentRegex.Location = new System.Drawing.Point(3, 123);
            this.fieldChapterContentRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterContentRegex.Name = "fieldChapterContentRegex";
            this.fieldChapterContentRegex.Size = new System.Drawing.Size(294, 54);
            this.fieldChapterContentRegex.TabIndex = 2;
            // 
            // fieldChapterSourceChoiceRegex
            // 
            this.fieldChapterSourceChoiceRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterSourceChoiceRegex.Label = "ChapterSourceChoiceRegex";
            this.fieldChapterSourceChoiceRegex.Location = new System.Drawing.Point(3, 63);
            this.fieldChapterSourceChoiceRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterSourceChoiceRegex.Name = "fieldChapterSourceChoiceRegex";
            this.fieldChapterSourceChoiceRegex.Size = new System.Drawing.Size(294, 54);
            this.fieldChapterSourceChoiceRegex.TabIndex = 1;
            // 
            // fieldChapterTitleRegex
            // 
            this.fieldChapterTitleRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterTitleRegex.Label = "ChapterTitleRegex";
            this.fieldChapterTitleRegex.Location = new System.Drawing.Point(3, 3);
            this.fieldChapterTitleRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterTitleRegex.Name = "fieldChapterTitleRegex";
            this.fieldChapterTitleRegex.Size = new System.Drawing.Size(294, 54);
            this.fieldChapterTitleRegex.TabIndex = 0;
            // 
            // fieldChapterChoicesChunkRegex
            // 
            this.fieldChapterChoicesChunkRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterChoicesChunkRegex.Label = "ChapterChoicesChunkRegex";
            this.fieldChapterChoicesChunkRegex.Location = new System.Drawing.Point(3, 363);
            this.fieldChapterChoicesChunkRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterChoicesChunkRegex.Name = "fieldChapterChoicesChunkRegex";
            this.fieldChapterChoicesChunkRegex.Size = new System.Drawing.Size(294, 54);
            this.fieldChapterChoicesChunkRegex.TabIndex = 6;
            // 
            // fieldChapterChoicesRegex
            // 
            this.fieldChapterChoicesRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterChoicesRegex.Label = "ChapterChoicesRegex";
            this.fieldChapterChoicesRegex.Location = new System.Drawing.Point(3, 423);
            this.fieldChapterChoicesRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterChoicesRegex.Name = "fieldChapterChoicesRegex";
            this.fieldChapterChoicesRegex.Size = new System.Drawing.Size(294, 54);
            this.fieldChapterChoicesRegex.TabIndex = 7;
            // 
            // fieldChapterChoiceUrlRegex
            // 
            this.fieldChapterChoiceUrlRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterChoiceUrlRegex.Label = "ChapterChoiceUrlRegex";
            this.fieldChapterChoiceUrlRegex.Location = new System.Drawing.Point(3, 483);
            this.fieldChapterChoiceUrlRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterChoiceUrlRegex.Name = "fieldChapterChoiceUrlRegex";
            this.fieldChapterChoiceUrlRegex.Size = new System.Drawing.Size(294, 54);
            this.fieldChapterChoiceUrlRegex.TabIndex = 8;
            // 
            // fieldChapterEndCheckRegex
            // 
            this.fieldChapterEndCheckRegex.Dock = System.Windows.Forms.DockStyle.Top;
            this.fieldChapterEndCheckRegex.Label = "ChapterEndCheckRegex";
            this.fieldChapterEndCheckRegex.Location = new System.Drawing.Point(3, 543);
            this.fieldChapterEndCheckRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterEndCheckRegex.Name = "fieldChapterEndCheckRegex";
            this.fieldChapterEndCheckRegex.Size = new System.Drawing.Size(294, 54);
            this.fieldChapterEndCheckRegex.TabIndex = 9;
            // 
            // WdcReaderTesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 590);
            this.Controls.Add(this.tableLayoutFormWrapper);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WdcReaderTesterForm";
            this.Text = "WDC Reader Tester";
            this.tableLayoutStoryFields.ResumeLayout(false);
            this.tabControlModeSelect.ResumeLayout(false);
            this.tabPageStory.ResumeLayout(false);
            this.tabPageChapterMap.ResumeLayout(false);
            this.tabPageChapter.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutStory.ResumeLayout(false);
            this.panelStoryFields.ResumeLayout(false);
            this.panelStoryFields.PerformLayout();
            this.tableLayoutFormWrapper.ResumeLayout(false);
            this.gbInputContent.ResumeLayout(false);
            this.gbInputContent.PerformLayout();
            this.gbOptions.ResumeLayout(false);
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.tableLayoutChapter.ResumeLayout(false);
            this.panelChapterFields.ResumeLayout(false);
            this.tableLayoutChapterFields.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContentInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStoryFields;
        private System.Windows.Forms.TabControl tabControlModeSelect;
        private System.Windows.Forms.TabPage tabPageStory;
        private System.Windows.Forms.TabPage tabPageChapterMap;
        private System.Windows.Forms.TabPage tabPageChapter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private Controls.WdcTesterOptionControl fieldInteractiveShortDescriptionRegex;
        private System.Windows.Forms.Button btnReadStory;
        private Controls.WdcTesterOptionControl fieldInteractiveTitleRegex;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStory;
        private System.Windows.Forms.Panel panelStoryFields;
        private Controls.WdcTesterOptionControl fieldInteractiveDescriptionRegex;
        private System.Windows.Forms.TableLayoutPanel tableLayoutFormWrapper;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.GroupBox gbInputContent;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutChapter;
        private System.Windows.Forms.Button btnReadChapter;
        private System.Windows.Forms.Panel panelChapterFields;
        private System.Windows.Forms.TableLayoutPanel tableLayoutChapterFields;
        private Controls.WdcTesterOptionControl fieldChapterAuthorNameRegex;
        private Controls.WdcTesterOptionControl fieldChapterAuthorUsernameRegex;
        private Controls.WdcTesterOptionControl fieldChapterAuthorChunkRegex;
        private Controls.WdcTesterOptionControl fieldChapterContentRegex;
        private Controls.WdcTesterOptionControl fieldChapterSourceChoiceRegex;
        private Controls.WdcTesterOptionControl fieldChapterTitleRegex;
        private Controls.WdcTesterOptionControl fieldChapterChoicesChunkRegex;
        private Controls.WdcTesterOptionControl fieldChapterChoicesRegex;
        private Controls.WdcTesterOptionControl fieldChapterChoiceUrlRegex;
        private Controls.WdcTesterOptionControl fieldChapterEndCheckRegex;
        private System.Windows.Forms.Button btnReadChapterMap;
    }
}
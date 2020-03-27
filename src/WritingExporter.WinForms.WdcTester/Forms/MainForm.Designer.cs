namespace WritingExporter.WinForms.WdcTester.Forms
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowStoryFields = new System.Windows.Forms.FlowLayoutPanel();
            this.fieldInteractiveTitleRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldInteractiveShortDescriptionRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldInteractiveDescriptionRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.btnReadStory = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableChapter = new System.Windows.Forms.TableLayoutPanel();
            this.btnReadChapter = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableFormWrapper = new System.Windows.Forms.TableLayoutPanel();
            this.tableChapterFields = new System.Windows.Forms.TableLayoutPanel();
            this.fieldChapterEndCheckRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldChapterChoiceUrlRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldChapterTitleRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldChapterSourceChoiceRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldChapterContentRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldChapterAuthorChunkRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldChapterAuthorUsernameRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldChapterAuthorNameRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldChapterChoicesChunkRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.fieldChapterChoicesRegex = new WritingExporter.WinForms.WdcTester.FormControls.EasyFieldControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowStoryFields.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableChapter.SuspendLayout();
            this.tableFormWrapper.SuspendLayout();
            this.tableChapterFields.SuspendLayout();
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
            this.txtContentInput.Size = new System.Drawing.Size(170, 144);
            this.txtContentInput.TabIndex = 2;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 16);
            this.txtOutput.MaxLength = 0;
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(442, 88);
            this.txtOutput.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtContentInput);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 163);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test content";
            // 
            // groupBox2
            // 
            this.tableFormWrapper.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.txtOutput);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 107);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(183, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(267, 163);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(411, 230);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Story";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowStoryFields, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnReadStory, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 224);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowStoryFields
            // 
            this.flowStoryFields.AutoScroll = true;
            this.flowStoryFields.Controls.Add(this.fieldInteractiveTitleRegex);
            this.flowStoryFields.Controls.Add(this.fieldInteractiveShortDescriptionRegex);
            this.flowStoryFields.Controls.Add(this.fieldInteractiveDescriptionRegex);
            this.flowStoryFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowStoryFields.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowStoryFields.Location = new System.Drawing.Point(3, 33);
            this.flowStoryFields.Name = "flowStoryFields";
            this.flowStoryFields.Size = new System.Drawing.Size(399, 188);
            this.flowStoryFields.TabIndex = 8;
            this.flowStoryFields.WrapContents = false;
            // 
            // fieldInteractiveTitleRegex
            // 
            this.fieldInteractiveTitleRegex.Label = "InteractiveTitleRegex";
            this.fieldInteractiveTitleRegex.Location = new System.Drawing.Point(2, 2);
            this.fieldInteractiveTitleRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldInteractiveTitleRegex.Name = "fieldInteractiveTitleRegex";
            this.fieldInteractiveTitleRegex.Size = new System.Drawing.Size(328, 54);
            this.fieldInteractiveTitleRegex.TabIndex = 0;
            // 
            // fieldInteractiveShortDescriptionRegex
            // 
            this.fieldInteractiveShortDescriptionRegex.Label = "InteractiveShortDescriptionRegex";
            this.fieldInteractiveShortDescriptionRegex.Location = new System.Drawing.Point(2, 62);
            this.fieldInteractiveShortDescriptionRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldInteractiveShortDescriptionRegex.Name = "fieldInteractiveShortDescriptionRegex";
            this.fieldInteractiveShortDescriptionRegex.Size = new System.Drawing.Size(262, 43);
            this.fieldInteractiveShortDescriptionRegex.TabIndex = 1;
            // 
            // fieldInteractiveDescriptionRegex
            // 
            this.fieldInteractiveDescriptionRegex.Label = "InteractiveDescriptionRegex";
            this.fieldInteractiveDescriptionRegex.Location = new System.Drawing.Point(2, 110);
            this.fieldInteractiveDescriptionRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldInteractiveDescriptionRegex.Name = "fieldInteractiveDescriptionRegex";
            this.fieldInteractiveDescriptionRegex.Size = new System.Drawing.Size(262, 43);
            this.fieldInteractiveDescriptionRegex.TabIndex = 2;
            // 
            // btnReadStory
            // 
            this.btnReadStory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReadStory.Location = new System.Drawing.Point(3, 3);
            this.btnReadStory.Name = "btnReadStory";
            this.btnReadStory.Size = new System.Drawing.Size(399, 24);
            this.btnReadStory.TabIndex = 6;
            this.btnReadStory.Text = "Read story";
            this.btnReadStory.UseVisualStyleBackColor = true;
            this.btnReadStory.Click += new System.EventHandler(this.btnReadStory_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableChapter);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(259, 137);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chapter";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableChapter
            // 
            this.tableChapter.ColumnCount = 1;
            this.tableChapter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableChapter.Controls.Add(this.tableChapterFields, 0, 1);
            this.tableChapter.Controls.Add(this.btnReadChapter, 0, 0);
            this.tableChapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableChapter.Location = new System.Drawing.Point(3, 3);
            this.tableChapter.Name = "tableChapter";
            this.tableChapter.RowCount = 2;
            this.tableChapter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableChapter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableChapter.Size = new System.Drawing.Size(253, 131);
            this.tableChapter.TabIndex = 0;
            // 
            // btnReadChapter
            // 
            this.btnReadChapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReadChapter.Location = new System.Drawing.Point(3, 3);
            this.btnReadChapter.Name = "btnReadChapter";
            this.btnReadChapter.Size = new System.Drawing.Size(247, 24);
            this.btnReadChapter.TabIndex = 0;
            this.btnReadChapter.Text = "Read chapter";
            this.btnReadChapter.UseVisualStyleBackColor = true;
            this.btnReadChapter.Click += new System.EventHandler(this.btnReadChapter_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(411, 230);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Chapter list";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableFormWrapper
            // 
            this.tableFormWrapper.ColumnCount = 2;
            this.tableFormWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableFormWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableFormWrapper.Controls.Add(this.tabControl1, 1, 0);
            this.tableFormWrapper.Controls.Add(this.groupBox2, 0, 1);
            this.tableFormWrapper.Controls.Add(this.groupBox1, 0, 0);
            this.tableFormWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableFormWrapper.Location = new System.Drawing.Point(0, 0);
            this.tableFormWrapper.Name = "tableFormWrapper";
            this.tableFormWrapper.RowCount = 2;
            this.tableFormWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableFormWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableFormWrapper.Size = new System.Drawing.Size(566, 350);
            this.tableFormWrapper.TabIndex = 8;
            // 
            // tableChapterFields
            // 
            this.tableChapterFields.AutoScroll = true;
            this.tableChapterFields.ColumnCount = 1;
            this.tableChapterFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableChapterFields.Controls.Add(this.fieldChapterChoicesRegex, 0, 7);
            this.tableChapterFields.Controls.Add(this.fieldChapterChoicesChunkRegex, 0, 6);
            this.tableChapterFields.Controls.Add(this.fieldChapterAuthorNameRegex, 0, 5);
            this.tableChapterFields.Controls.Add(this.fieldChapterAuthorUsernameRegex, 0, 4);
            this.tableChapterFields.Controls.Add(this.fieldChapterAuthorChunkRegex, 0, 3);
            this.tableChapterFields.Controls.Add(this.fieldChapterContentRegex, 0, 2);
            this.tableChapterFields.Controls.Add(this.fieldChapterSourceChoiceRegex, 0, 1);
            this.tableChapterFields.Controls.Add(this.fieldChapterTitleRegex, 0, 0);
            this.tableChapterFields.Controls.Add(this.fieldChapterChoiceUrlRegex, 0, 8);
            this.tableChapterFields.Controls.Add(this.fieldChapterEndCheckRegex, 0, 9);
            this.tableChapterFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableChapterFields.Location = new System.Drawing.Point(3, 33);
            this.tableChapterFields.Name = "tableChapterFields";
            this.tableChapterFields.RowCount = 11;
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableChapterFields.Size = new System.Drawing.Size(247, 95);
            this.tableChapterFields.TabIndex = 0;
            // 
            // fieldChapterEndCheckRegex
            // 
            this.fieldChapterEndCheckRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterEndCheckRegex.Label = "ChapterEndCheckRegex";
            this.fieldChapterEndCheckRegex.Location = new System.Drawing.Point(3, 444);
            this.fieldChapterEndCheckRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterEndCheckRegex.Name = "fieldChapterEndCheckRegex";
            this.fieldChapterEndCheckRegex.Size = new System.Drawing.Size(224, 54);
            this.fieldChapterEndCheckRegex.TabIndex = 16;
            // 
            // fieldChapterChoiceUrlRegex
            // 
            this.fieldChapterChoiceUrlRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterChoiceUrlRegex.Label = "ChapterChoiceUrlRegex";
            this.fieldChapterChoiceUrlRegex.Location = new System.Drawing.Point(3, 395);
            this.fieldChapterChoiceUrlRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterChoiceUrlRegex.Name = "fieldChapterChoiceUrlRegex";
            this.fieldChapterChoiceUrlRegex.Size = new System.Drawing.Size(224, 54);
            this.fieldChapterChoiceUrlRegex.TabIndex = 17;
            // 
            // fieldChapterTitleRegex
            // 
            this.fieldChapterTitleRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterTitleRegex.Label = "ChapterTitleRegex";
            this.fieldChapterTitleRegex.Location = new System.Drawing.Point(3, 3);
            this.fieldChapterTitleRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterTitleRegex.Name = "fieldChapterTitleRegex";
            this.fieldChapterTitleRegex.Size = new System.Drawing.Size(224, 54);
            this.fieldChapterTitleRegex.TabIndex = 20;
            // 
            // fieldChapterSourceChoiceRegex
            // 
            this.fieldChapterSourceChoiceRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterSourceChoiceRegex.Label = "ChapterSourceChoiceRegex";
            this.fieldChapterSourceChoiceRegex.Location = new System.Drawing.Point(3, 52);
            this.fieldChapterSourceChoiceRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterSourceChoiceRegex.Name = "fieldChapterSourceChoiceRegex";
            this.fieldChapterSourceChoiceRegex.Size = new System.Drawing.Size(224, 54);
            this.fieldChapterSourceChoiceRegex.TabIndex = 21;
            // 
            // fieldChapterContentRegex
            // 
            this.fieldChapterContentRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterContentRegex.Label = "ChapterContentRegex";
            this.fieldChapterContentRegex.Location = new System.Drawing.Point(3, 101);
            this.fieldChapterContentRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterContentRegex.Name = "fieldChapterContentRegex";
            this.fieldChapterContentRegex.Size = new System.Drawing.Size(224, 54);
            this.fieldChapterContentRegex.TabIndex = 22;
            // 
            // fieldChapterAuthorChunkRegex
            // 
            this.fieldChapterAuthorChunkRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterAuthorChunkRegex.Label = "ChapterAuthorChunkRegex";
            this.fieldChapterAuthorChunkRegex.Location = new System.Drawing.Point(3, 150);
            this.fieldChapterAuthorChunkRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterAuthorChunkRegex.Name = "fieldChapterAuthorChunkRegex";
            this.fieldChapterAuthorChunkRegex.Size = new System.Drawing.Size(224, 54);
            this.fieldChapterAuthorChunkRegex.TabIndex = 23;
            // 
            // fieldChapterAuthorUsernameRegex
            // 
            this.fieldChapterAuthorUsernameRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterAuthorUsernameRegex.Label = "ChapterAuthorUsernameRegex";
            this.fieldChapterAuthorUsernameRegex.Location = new System.Drawing.Point(3, 199);
            this.fieldChapterAuthorUsernameRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterAuthorUsernameRegex.Name = "fieldChapterAuthorUsernameRegex";
            this.fieldChapterAuthorUsernameRegex.Size = new System.Drawing.Size(224, 54);
            this.fieldChapterAuthorUsernameRegex.TabIndex = 24;
            // 
            // fieldChapterAuthorNameRegex
            // 
            this.fieldChapterAuthorNameRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterAuthorNameRegex.Label = "ChapterAuthorNameRegex";
            this.fieldChapterAuthorNameRegex.Location = new System.Drawing.Point(3, 248);
            this.fieldChapterAuthorNameRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterAuthorNameRegex.Name = "fieldChapterAuthorNameRegex";
            this.fieldChapterAuthorNameRegex.Size = new System.Drawing.Size(224, 54);
            this.fieldChapterAuthorNameRegex.TabIndex = 25;
            // 
            // fieldChapterChoicesChunkRegex
            // 
            this.fieldChapterChoicesChunkRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterChoicesChunkRegex.Label = "ChapterChoicesChunkRegex";
            this.fieldChapterChoicesChunkRegex.Location = new System.Drawing.Point(3, 297);
            this.fieldChapterChoicesChunkRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterChoicesChunkRegex.Name = "fieldChapterChoicesChunkRegex";
            this.fieldChapterChoicesChunkRegex.Size = new System.Drawing.Size(224, 54);
            this.fieldChapterChoicesChunkRegex.TabIndex = 26;
            // 
            // fieldChapterChoicesRegex
            // 
            this.fieldChapterChoicesRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldChapterChoicesRegex.Label = "ChapterChoicesRegex";
            this.fieldChapterChoicesRegex.Location = new System.Drawing.Point(3, 346);
            this.fieldChapterChoicesRegex.MinimumSize = new System.Drawing.Size(100, 54);
            this.fieldChapterChoicesRegex.Name = "fieldChapterChoicesRegex";
            this.fieldChapterChoicesRegex.Size = new System.Drawing.Size(224, 54);
            this.fieldChapterChoicesRegex.TabIndex = 27;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 438);
            this.Controls.Add(this.tableFormWrapper);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowStoryFields.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableChapter.ResumeLayout(false);
            this.tableFormWrapper.ResumeLayout(false);
            this.tableChapterFields.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtContentInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableChapter;
        private System.Windows.Forms.Button btnReadChapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowStoryFields;
        private FormControls.EasyFieldControl fieldInteractiveTitleRegex;
        private FormControls.EasyFieldControl fieldInteractiveShortDescriptionRegex;
        private FormControls.EasyFieldControl fieldInteractiveDescriptionRegex;
        private System.Windows.Forms.Button btnReadStory;
        private System.Windows.Forms.TableLayoutPanel tableFormWrapper;
        private System.Windows.Forms.TableLayoutPanel tableChapterFields;
        private FormControls.EasyFieldControl fieldChapterChoicesRegex;
        private FormControls.EasyFieldControl fieldChapterChoicesChunkRegex;
        private FormControls.EasyFieldControl fieldChapterAuthorNameRegex;
        private FormControls.EasyFieldControl fieldChapterAuthorUsernameRegex;
        private FormControls.EasyFieldControl fieldChapterAuthorChunkRegex;
        private FormControls.EasyFieldControl fieldChapterContentRegex;
        private FormControls.EasyFieldControl fieldChapterSourceChoiceRegex;
        private FormControls.EasyFieldControl fieldChapterTitleRegex;
        private FormControls.EasyFieldControl fieldChapterChoiceUrlRegex;
        private FormControls.EasyFieldControl fieldChapterEndCheckRegex;
    }
}
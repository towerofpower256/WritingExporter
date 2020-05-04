namespace WritingExporter.WinForms.Forms
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWDCReaderTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvStories = new System.Windows.Forms.DataGridView();
            this.dgvStoriesColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStoriesColState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStoriesColChapters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStoriesColLastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStoryInfo = new System.Windows.Forms.TextBox();
            this.lblSyncWorkerState = new System.Windows.Forms.Label();
            this.lblSyncWorkerMessage = new System.Windows.Forms.Label();
            this.lblSyncWorkerCurrentTask = new System.Windows.Forms.Label();
            this.lblSyncWorkerStateLabel = new System.Windows.Forms.Label();
            this.lblSyncWorkerMessageLabel = new System.Windows.Forms.Label();
            this.lblSyncWorkerCurrentTaskLabel = new System.Windows.Forms.Label();
            this.btnSyncWorkerStart = new System.Windows.Forms.Button();
            this.btnSyncWorkerStop = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStories)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem,
            this.openWDCReaderTesterToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addStoryToolStripMenuItem
            // 
            this.addStoryToolStripMenuItem.Name = "addStoryToolStripMenuItem";
            this.addStoryToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.addStoryToolStripMenuItem.Text = "&Add story";
            this.addStoryToolStripMenuItem.Click += new System.EventHandler(this.addStoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // openWDCReaderTesterToolStripMenuItem
            // 
            this.openWDCReaderTesterToolStripMenuItem.Name = "openWDCReaderTesterToolStripMenuItem";
            this.openWDCReaderTesterToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openWDCReaderTesterToolStripMenuItem.Text = "Open WDC reader tester";
            this.openWDCReaderTesterToolStripMenuItem.Click += new System.EventHandler(this.openWDCReaderTesterToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // dgvStories
            // 
            this.dgvStories.AllowUserToAddRows = false;
            this.dgvStories.AllowUserToDeleteRows = false;
            this.dgvStories.AllowUserToResizeRows = false;
            this.dgvStories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvStoriesColName,
            this.dgvStoriesColState,
            this.dgvStoriesColChapters,
            this.dgvStoriesColLastUpdated});
            this.dgvStories.Location = new System.Drawing.Point(12, 43);
            this.dgvStories.MultiSelect = false;
            this.dgvStories.Name = "dgvStories";
            this.dgvStories.ReadOnly = true;
            this.dgvStories.RowHeadersVisible = false;
            this.dgvStories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStories.Size = new System.Drawing.Size(752, 238);
            this.dgvStories.TabIndex = 1;
            this.dgvStories.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStories_CellMouseClick);
            this.dgvStories.SelectionChanged += new System.EventHandler(this.dgvStories_SelectionChanged);
            // 
            // dgvStoriesColName
            // 
            this.dgvStoriesColName.HeaderText = "Name";
            this.dgvStoriesColName.Name = "dgvStoriesColName";
            this.dgvStoriesColName.ReadOnly = true;
            // 
            // dgvStoriesColState
            // 
            this.dgvStoriesColState.HeaderText = "State";
            this.dgvStoriesColState.Name = "dgvStoriesColState";
            this.dgvStoriesColState.ReadOnly = true;
            // 
            // dgvStoriesColChapters
            // 
            this.dgvStoriesColChapters.HeaderText = "Chapters";
            this.dgvStoriesColChapters.Name = "dgvStoriesColChapters";
            this.dgvStoriesColChapters.ReadOnly = true;
            // 
            // dgvStoriesColLastUpdated
            // 
            this.dgvStoriesColLastUpdated.HeaderText = "Last updated";
            this.dgvStoriesColLastUpdated.Name = "dgvStoriesColLastUpdated";
            this.dgvStoriesColLastUpdated.ReadOnly = true;
            // 
            // txtStoryInfo
            // 
            this.txtStoryInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtStoryInfo.Location = new System.Drawing.Point(388, 287);
            this.txtStoryInfo.Multiline = true;
            this.txtStoryInfo.Name = "txtStoryInfo";
            this.txtStoryInfo.ReadOnly = true;
            this.txtStoryInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStoryInfo.Size = new System.Drawing.Size(376, 205);
            this.txtStoryInfo.TabIndex = 2;
            // 
            // lblSyncWorkerState
            // 
            this.lblSyncWorkerState.AutoSize = true;
            this.lblSyncWorkerState.Location = new System.Drawing.Point(81, 327);
            this.lblSyncWorkerState.Name = "lblSyncWorkerState";
            this.lblSyncWorkerState.Size = new System.Drawing.Size(101, 13);
            this.lblSyncWorkerState.TabIndex = 3;
            this.lblSyncWorkerState.Text = "lblSyncWorkerState";
            // 
            // lblSyncWorkerMessage
            // 
            this.lblSyncWorkerMessage.AutoSize = true;
            this.lblSyncWorkerMessage.Location = new System.Drawing.Point(81, 359);
            this.lblSyncWorkerMessage.Name = "lblSyncWorkerMessage";
            this.lblSyncWorkerMessage.Size = new System.Drawing.Size(119, 13);
            this.lblSyncWorkerMessage.TabIndex = 4;
            this.lblSyncWorkerMessage.Text = "lblSyncWorkerMessage";
            // 
            // lblSyncWorkerCurrentTask
            // 
            this.lblSyncWorkerCurrentTask.AutoSize = true;
            this.lblSyncWorkerCurrentTask.Location = new System.Drawing.Point(81, 387);
            this.lblSyncWorkerCurrentTask.Name = "lblSyncWorkerCurrentTask";
            this.lblSyncWorkerCurrentTask.Size = new System.Drawing.Size(134, 13);
            this.lblSyncWorkerCurrentTask.TabIndex = 5;
            this.lblSyncWorkerCurrentTask.Text = "lblSyncWorkerCurrentTask";
            // 
            // lblSyncWorkerStateLabel
            // 
            this.lblSyncWorkerStateLabel.AutoSize = true;
            this.lblSyncWorkerStateLabel.Location = new System.Drawing.Point(13, 326);
            this.lblSyncWorkerStateLabel.Name = "lblSyncWorkerStateLabel";
            this.lblSyncWorkerStateLabel.Size = new System.Drawing.Size(35, 13);
            this.lblSyncWorkerStateLabel.TabIndex = 6;
            this.lblSyncWorkerStateLabel.Text = "State:";
            // 
            // lblSyncWorkerMessageLabel
            // 
            this.lblSyncWorkerMessageLabel.AutoSize = true;
            this.lblSyncWorkerMessageLabel.Location = new System.Drawing.Point(13, 359);
            this.lblSyncWorkerMessageLabel.Name = "lblSyncWorkerMessageLabel";
            this.lblSyncWorkerMessageLabel.Size = new System.Drawing.Size(53, 13);
            this.lblSyncWorkerMessageLabel.TabIndex = 7;
            this.lblSyncWorkerMessageLabel.Text = "Message:";
            // 
            // lblSyncWorkerCurrentTaskLabel
            // 
            this.lblSyncWorkerCurrentTaskLabel.AutoSize = true;
            this.lblSyncWorkerCurrentTaskLabel.Location = new System.Drawing.Point(13, 387);
            this.lblSyncWorkerCurrentTaskLabel.Name = "lblSyncWorkerCurrentTaskLabel";
            this.lblSyncWorkerCurrentTaskLabel.Size = new System.Drawing.Size(67, 13);
            this.lblSyncWorkerCurrentTaskLabel.TabIndex = 8;
            this.lblSyncWorkerCurrentTaskLabel.Text = "Current task:";
            // 
            // btnSyncWorkerStart
            // 
            this.btnSyncWorkerStart.Location = new System.Drawing.Point(34, 421);
            this.btnSyncWorkerStart.Name = "btnSyncWorkerStart";
            this.btnSyncWorkerStart.Size = new System.Drawing.Size(55, 23);
            this.btnSyncWorkerStart.TabIndex = 9;
            this.btnSyncWorkerStart.Text = "▶";
            this.btnSyncWorkerStart.UseVisualStyleBackColor = true;
            this.btnSyncWorkerStart.Click += new System.EventHandler(this.btnSyncWorkerStart_Click);
            // 
            // btnSyncWorkerStop
            // 
            this.btnSyncWorkerStop.Location = new System.Drawing.Point(95, 421);
            this.btnSyncWorkerStop.Name = "btnSyncWorkerStop";
            this.btnSyncWorkerStop.Size = new System.Drawing.Size(55, 23);
            this.btnSyncWorkerStop.TabIndex = 10;
            this.btnSyncWorkerStop.Text = "■";
            this.btnSyncWorkerStop.UseVisualStyleBackColor = true;
            this.btnSyncWorkerStop.Click += new System.EventHandler(this.btnSyncWorkerStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.btnSyncWorkerStop);
            this.Controls.Add(this.btnSyncWorkerStart);
            this.Controls.Add(this.lblSyncWorkerCurrentTaskLabel);
            this.Controls.Add(this.lblSyncWorkerMessageLabel);
            this.Controls.Add(this.lblSyncWorkerStateLabel);
            this.Controls.Add(this.lblSyncWorkerCurrentTask);
            this.Controls.Add(this.lblSyncWorkerMessage);
            this.Controls.Add(this.lblSyncWorkerState);
            this.Controls.Add(this.txtStoryInfo);
            this.Controls.Add(this.dgvStories);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWDCReaderTesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dgvStories;
        private System.Windows.Forms.TextBox txtStoryInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStoriesColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStoriesColState;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStoriesColChapters;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStoriesColLastUpdated;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label lblSyncWorkerState;
        private System.Windows.Forms.Label lblSyncWorkerMessage;
        private System.Windows.Forms.Label lblSyncWorkerCurrentTask;
        private System.Windows.Forms.Label lblSyncWorkerStateLabel;
        private System.Windows.Forms.Label lblSyncWorkerMessageLabel;
        private System.Windows.Forms.Label lblSyncWorkerCurrentTaskLabel;
        private System.Windows.Forms.Button btnSyncWorkerStart;
        private System.Windows.Forms.Button btnSyncWorkerStop;
    }
}
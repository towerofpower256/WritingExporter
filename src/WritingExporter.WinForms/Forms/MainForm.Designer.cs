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
            this.dgvStories = new System.Windows.Forms.DataGridView();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.dgvColOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColChapters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddStory = new System.Windows.Forms.Button();
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
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // dgvStories
            // 
            this.dgvStories.AllowUserToAddRows = false;
            this.dgvStories.AllowUserToDeleteRows = false;
            this.dgvStories.AllowUserToOrderColumns = true;
            this.dgvStories.AllowUserToResizeColumns = false;
            this.dgvStories.AllowUserToResizeRows = false;
            this.dgvStories.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvStories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColOrder,
            this.dgvColStatus,
            this.dgvColName,
            this.dgvColChapters});
            this.dgvStories.Location = new System.Drawing.Point(12, 27);
            this.dgvStories.MultiSelect = false;
            this.dgvStories.Name = "dgvStories";
            this.dgvStories.ReadOnly = true;
            this.dgvStories.RowHeadersVisible = false;
            this.dgvStories.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStories.ShowEditingIcon = false;
            this.dgvStories.Size = new System.Drawing.Size(349, 286);
            this.dgvStories.TabIndex = 1;
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtInfo.Location = new System.Drawing.Point(424, 106);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(270, 207);
            this.txtInfo.TabIndex = 2;
            // 
            // dgvColOrder
            // 
            this.dgvColOrder.HeaderText = "Order";
            this.dgvColOrder.Name = "dgvColOrder";
            this.dgvColOrder.ReadOnly = true;
            // 
            // dgvColStatus
            // 
            this.dgvColStatus.HeaderText = "Status";
            this.dgvColStatus.Name = "dgvColStatus";
            this.dgvColStatus.ReadOnly = true;
            // 
            // dgvColName
            // 
            this.dgvColName.HeaderText = "Name";
            this.dgvColName.Name = "dgvColName";
            this.dgvColName.ReadOnly = true;
            // 
            // dgvColChapters
            // 
            this.dgvColChapters.HeaderText = "Chapters";
            this.dgvColChapters.Name = "dgvColChapters";
            this.dgvColChapters.ReadOnly = true;
            // 
            // btnAddStory
            // 
            this.btnAddStory.Location = new System.Drawing.Point(307, 354);
            this.btnAddStory.Name = "btnAddStory";
            this.btnAddStory.Size = new System.Drawing.Size(75, 23);
            this.btnAddStory.TabIndex = 3;
            this.btnAddStory.Text = "Add story";
            this.btnAddStory.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddStory);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.dgvStories);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvStories;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColChapters;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnAddStory;
    }
}
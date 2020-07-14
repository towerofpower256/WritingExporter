namespace WritingExporter.WinForms.Forms
{
    partial class BrowseStoryForm
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
            this.dgvChapters = new System.Windows.Forms.DataGridView();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.tblWrapper = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.flowPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnFirstSeen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnLastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChapters)).BeginInit();
            this.tblWrapper.SuspendLayout();
            this.flowPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChapters
            // 
            this.dgvChapters.AllowUserToAddRows = false;
            this.dgvChapters.AllowUserToDeleteRows = false;
            this.dgvChapters.AllowUserToResizeRows = false;
            this.dgvChapters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChapters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnId,
            this.dgvColumnIndex,
            this.dgvColumnTitle,
            this.dgvColumnFirstSeen,
            this.dgvColumnLastUpdated});
            this.dgvChapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChapters.Location = new System.Drawing.Point(3, 3);
            this.dgvChapters.MultiSelect = false;
            this.dgvChapters.Name = "dgvChapters";
            this.dgvChapters.ReadOnly = true;
            this.dgvChapters.RowHeadersVisible = false;
            this.dgvChapters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChapters.Size = new System.Drawing.Size(394, 404);
            this.dgvChapters.TabIndex = 0;
            this.dgvChapters.SelectionChanged += new System.EventHandler(this.dgvChapters_SelectionChanged);
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point(403, 3);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(394, 404);
            this.txtInfo.TabIndex = 1;
            // 
            // tblWrapper
            // 
            this.tblWrapper.ColumnCount = 2;
            this.tblWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWrapper.Controls.Add(this.txtInfo, 1, 0);
            this.tblWrapper.Controls.Add(this.dgvChapters, 0, 0);
            this.tblWrapper.Controls.Add(this.flowPanelButtons, 0, 1);
            this.tblWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblWrapper.Location = new System.Drawing.Point(0, 0);
            this.tblWrapper.Name = "tblWrapper";
            this.tblWrapper.RowCount = 2;
            this.tblWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblWrapper.Size = new System.Drawing.Size(800, 450);
            this.tblWrapper.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // flowPanelButtons
            // 
            this.tblWrapper.SetColumnSpan(this.flowPanelButtons, 2);
            this.flowPanelButtons.Controls.Add(this.btnRefresh);
            this.flowPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelButtons.Location = new System.Drawing.Point(3, 413);
            this.flowPanelButtons.Name = "flowPanelButtons";
            this.flowPanelButtons.Size = new System.Drawing.Size(794, 34);
            this.flowPanelButtons.TabIndex = 2;
            // 
            // dgvColumnId
            // 
            this.dgvColumnId.DataPropertyName = "Id";
            this.dgvColumnId.HeaderText = "Id";
            this.dgvColumnId.Name = "dgvColumnId";
            this.dgvColumnId.ReadOnly = true;
            this.dgvColumnId.Visible = false;
            // 
            // dgvColumnIndex
            // 
            this.dgvColumnIndex.DataPropertyName = "Index";
            this.dgvColumnIndex.HeaderText = "Index";
            this.dgvColumnIndex.Name = "dgvColumnIndex";
            this.dgvColumnIndex.ReadOnly = true;
            // 
            // dgvColumnTitle
            // 
            this.dgvColumnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dgvColumnTitle.DataPropertyName = "Title";
            this.dgvColumnTitle.HeaderText = "Title";
            this.dgvColumnTitle.MinimumWidth = 50;
            this.dgvColumnTitle.Name = "dgvColumnTitle";
            this.dgvColumnTitle.ReadOnly = true;
            this.dgvColumnTitle.Width = 50;
            // 
            // dgvColumnFirstSeen
            // 
            this.dgvColumnFirstSeen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dgvColumnFirstSeen.DataPropertyName = "FirstSeen";
            this.dgvColumnFirstSeen.HeaderText = "First seen";
            this.dgvColumnFirstSeen.MinimumWidth = 30;
            this.dgvColumnFirstSeen.Name = "dgvColumnFirstSeen";
            this.dgvColumnFirstSeen.ReadOnly = true;
            this.dgvColumnFirstSeen.Width = 30;
            // 
            // dgvColumnLastUpdated
            // 
            this.dgvColumnLastUpdated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dgvColumnLastUpdated.DataPropertyName = "LastUpdated";
            this.dgvColumnLastUpdated.HeaderText = "Last updated";
            this.dgvColumnLastUpdated.MinimumWidth = 30;
            this.dgvColumnLastUpdated.Name = "dgvColumnLastUpdated";
            this.dgvColumnLastUpdated.ReadOnly = true;
            this.dgvColumnLastUpdated.Width = 30;
            // 
            // BrowseStoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblWrapper);
            this.Name = "BrowseStoryForm";
            this.Text = "Browse story";
            this.Load += new System.EventHandler(this.BrowseStoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChapters)).EndInit();
            this.tblWrapper.ResumeLayout(false);
            this.tblWrapper.PerformLayout();
            this.flowPanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChapters;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.TableLayoutPanel tblWrapper;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel flowPanelButtons;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnFirstSeen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnLastUpdated;
    }
}
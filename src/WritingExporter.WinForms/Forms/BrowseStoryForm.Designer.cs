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
            this.dgvColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.tblWrapper = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChapters)).BeginInit();
            this.tblWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChapters
            // 
            this.dgvChapters.AllowUserToAddRows = false;
            this.dgvChapters.AllowUserToDeleteRows = false;
            this.dgvChapters.AllowUserToResizeRows = false;
            this.dgvChapters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChapters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnIndex,
            this.dgvColumnTitle});
            this.dgvChapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChapters.Location = new System.Drawing.Point(3, 3);
            this.dgvChapters.MultiSelect = false;
            this.dgvChapters.Name = "dgvChapters";
            this.dgvChapters.ReadOnly = true;
            this.dgvChapters.RowHeadersVisible = false;
            this.dgvChapters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChapters.Size = new System.Drawing.Size(267, 318);
            this.dgvChapters.TabIndex = 0;
            this.dgvChapters.SelectionChanged += new System.EventHandler(this.dgvChapters_SelectionChanged);
            // 
            // dgvColumnIndex
            // 
            this.dgvColumnIndex.HeaderText = "Index";
            this.dgvColumnIndex.Name = "dgvColumnIndex";
            this.dgvColumnIndex.ReadOnly = true;
            // 
            // dgvColumnTitle
            // 
            this.dgvColumnTitle.HeaderText = "Title";
            this.dgvColumnTitle.Name = "dgvColumnTitle";
            this.dgvColumnTitle.ReadOnly = true;
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point(276, 3);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(268, 318);
            this.txtInfo.TabIndex = 1;
            // 
            // tblWrapper
            // 
            this.tblWrapper.ColumnCount = 2;
            this.tblWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWrapper.Controls.Add(this.txtInfo, 1, 0);
            this.tblWrapper.Controls.Add(this.dgvChapters, 0, 0);
            this.tblWrapper.Location = new System.Drawing.Point(125, 54);
            this.tblWrapper.Name = "tblWrapper";
            this.tblWrapper.RowCount = 1;
            this.tblWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblWrapper.Size = new System.Drawing.Size(547, 324);
            this.tblWrapper.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 380);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // BrowseStoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tblWrapper);
            this.Name = "BrowseStoryForm";
            this.Text = "Browse story - ";
            this.Load += new System.EventHandler(this.BrowseStoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChapters)).EndInit();
            this.tblWrapper.ResumeLayout(false);
            this.tblWrapper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChapters;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnTitle;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.TableLayoutPanel tblWrapper;
        private System.Windows.Forms.Button btnRefresh;
    }
}
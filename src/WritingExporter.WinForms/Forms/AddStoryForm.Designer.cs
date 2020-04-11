namespace WritingExporter.WinForms.Forms
{
    partial class AddStoryForm
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
            this.txtStoryUrl = new System.Windows.Forms.TextBox();
            this.btnAddStory = new System.Windows.Forms.Button();
            this.txtStoryInfo = new System.Windows.Forms.TextBox();
            this.btnGetStory = new System.Windows.Forms.Button();
            this.lblStoryUrl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStoryUrl
            // 
            this.txtStoryUrl.Location = new System.Drawing.Point(77, 12);
            this.txtStoryUrl.Name = "txtStoryUrl";
            this.txtStoryUrl.Size = new System.Drawing.Size(435, 20);
            this.txtStoryUrl.TabIndex = 0;
            // 
            // btnAddStory
            // 
            this.btnAddStory.Location = new System.Drawing.Point(12, 342);
            this.btnAddStory.Name = "btnAddStory";
            this.btnAddStory.Size = new System.Drawing.Size(500, 30);
            this.btnAddStory.TabIndex = 1;
            this.btnAddStory.Text = "Add story";
            this.btnAddStory.UseVisualStyleBackColor = true;
            // 
            // txtStoryInfo
            // 
            this.txtStoryInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtStoryInfo.Location = new System.Drawing.Point(12, 74);
            this.txtStoryInfo.Multiline = true;
            this.txtStoryInfo.Name = "txtStoryInfo";
            this.txtStoryInfo.ReadOnly = true;
            this.txtStoryInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStoryInfo.Size = new System.Drawing.Size(500, 262);
            this.txtStoryInfo.TabIndex = 2;
            // 
            // btnGetStory
            // 
            this.btnGetStory.Location = new System.Drawing.Point(12, 38);
            this.btnGetStory.Name = "btnGetStory";
            this.btnGetStory.Size = new System.Drawing.Size(500, 30);
            this.btnGetStory.TabIndex = 3;
            this.btnGetStory.Text = "Get story";
            this.btnGetStory.UseVisualStyleBackColor = true;
            // 
            // lblStoryUrl
            // 
            this.lblStoryUrl.AutoSize = true;
            this.lblStoryUrl.Location = new System.Drawing.Point(9, 15);
            this.lblStoryUrl.Name = "lblStoryUrl";
            this.lblStoryUrl.Size = new System.Drawing.Size(56, 13);
            this.lblStoryUrl.TabIndex = 4;
            this.lblStoryUrl.Text = "Story URL";
            // 
            // AddStoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 388);
            this.Controls.Add(this.lblStoryUrl);
            this.Controls.Add(this.btnGetStory);
            this.Controls.Add(this.txtStoryInfo);
            this.Controls.Add(this.btnAddStory);
            this.Controls.Add(this.txtStoryUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddStoryForm";
            this.Text = "Add story";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStoryUrl;
        private System.Windows.Forms.Button btnAddStory;
        private System.Windows.Forms.TextBox txtStoryInfo;
        private System.Windows.Forms.Button btnGetStory;
        private System.Windows.Forms.Label lblStoryUrl;
    }
}
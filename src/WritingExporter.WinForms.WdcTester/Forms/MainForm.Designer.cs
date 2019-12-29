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
            this.btnWdcReadToStory = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInputContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnWdcReadToStory
            // 
            this.btnWdcReadToStory.Location = new System.Drawing.Point(256, 45);
            this.btnWdcReadToStory.Name = "btnWdcReadToStory";
            this.btnWdcReadToStory.Size = new System.Drawing.Size(123, 23);
            this.btnWdcReadToStory.TabIndex = 0;
            this.btnWdcReadToStory.Text = "Read to story";
            this.btnWdcReadToStory.UseVisualStyleBackColor = true;
            this.btnWdcReadToStory.Click += new System.EventHandler(this.btnWdcReadToStory_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Location = new System.Drawing.Point(564, 19);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(224, 394);
            this.txtOutput.TabIndex = 2;
            // 
            // txtInputContent
            // 
            this.txtInputContent.Location = new System.Drawing.Point(22, 45);
            this.txtInputContent.Multiline = true;
            this.txtInputContent.Name = "txtInputContent";
            this.txtInputContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInputContent.Size = new System.Drawing.Size(206, 378);
            this.txtInputContent.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtInputContent);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnWdcReadToStory);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWdcReadToStory;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInputContent;
    }
}
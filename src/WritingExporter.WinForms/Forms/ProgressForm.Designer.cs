namespace WritingExporter.WinForms.Forms
{
    partial class ProgressForm
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
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Location = new System.Drawing.Point(51, 130);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(82, 13);
            this.lblStatusMessage.TabIndex = 0;
            this.lblStatusMessage.Text = "Status message";
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(72, 49);
            this.pbMain.Maximum = 1000;
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(425, 23);
            this.pbMain.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(218, 119);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(573, 306);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.lblStatusMessage);
            this.Name = "ProgressForm";
            this.Text = "ProgressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.ProgressBar pbMain;
        private System.Windows.Forms.Button btnCancel;
    }
}
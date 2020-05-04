namespace WritingExporter.WinForms.Forms
{
    partial class ConfigForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtWdcPassword = new WritingExporter.WinForms.Controls.WdcTextOptionControl();
            this.txtWdcUsername = new WritingExporter.WinForms.Controls.WdcTextOptionControl();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(698, 398);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(607, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtWdcPassword
            // 
            this.txtWdcPassword.Label = "Password";
            this.txtWdcPassword.Location = new System.Drawing.Point(12, 72);
            this.txtWdcPassword.MinimumSize = new System.Drawing.Size(100, 54);
            this.txtWdcPassword.Name = "txtWdcPassword";
            this.txtWdcPassword.PasswordChar = '●';
            this.txtWdcPassword.Size = new System.Drawing.Size(220, 54);
            this.txtWdcPassword.TabIndex = 1;
            this.txtWdcPassword.UsePasswordChar = true;
            // 
            // txtWdcUsername
            // 
            this.txtWdcUsername.Label = "Username";
            this.txtWdcUsername.Location = new System.Drawing.Point(12, 12);
            this.txtWdcUsername.MinimumSize = new System.Drawing.Size(100, 54);
            this.txtWdcUsername.Name = "txtWdcUsername";
            this.txtWdcUsername.PasswordChar = '\0';
            this.txtWdcUsername.Size = new System.Drawing.Size(220, 54);
            this.txtWdcUsername.TabIndex = 0;
            this.txtWdcUsername.UsePasswordChar = false;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtWdcPassword);
            this.Controls.Add(this.txtWdcUsername);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.WdcTextOptionControl txtWdcUsername;
        private Controls.WdcTextOptionControl txtWdcPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
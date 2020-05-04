﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WritingExporter.WinForms.Forms
{
    public partial class ExceptionDialogForm : Form
    {
        public ExceptionDialogForm()
        {
            InitializeComponent();

            picExceptionIcon.Image = SystemIcons.Error.ToBitmap();
        }

        public void SetInfo(string message, Exception ex)
        {
            this.Text = $"Exception occurred: {message}";
            txtInfo.Text = $"{message}\n\n{StringifyException(ex)}";
        }

        public static string StringifyException(Exception ex)
        {
            var sb = new StringBuilder();

            sb.AppendLine(ex.GetType().ToString());
            sb.AppendLine(ex.Message);
            sb.AppendLine();
            sb.AppendLine($"Source: " + ex.Source);
            sb.AppendLine();
            sb.AppendLine("Stack trace:");
            sb.AppendLine(ex.StackTrace);

            return sb.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtInfo.Text);
        }
    }
}
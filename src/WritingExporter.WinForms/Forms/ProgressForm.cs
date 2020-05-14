using System;
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
    public partial class ProgressForm : Form
    {
        public event EventHandler<EventArgs> OnCancel;

        public ProgressForm()
        {
            InitializeComponent();
        }

        public void DoCancel()
        {
            OnCancel?.Invoke(this, new EventArgs());
        }

        delegate void UpdateFormDelegate(int progressValue, int progressMax, string message);
        public void UpdateForm(int progressValue, int progressMax, string message)
        {
            if (this.IsDisposed || this.Disposing) return;

            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateFormDelegate(UpdateForm), new object[] { progressValue, progressMax, message });
                return;
            }

            if (progressMax == 0)
            {
                // Handle differently, to avoid divide by 0 issues
                pbMain.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                pbMain.Style = ProgressBarStyle.Continuous;
                int valueNormalised = (progressValue / progressMax) * 1000;
                if (valueNormalised < 0) valueNormalised = 0;
                pbMain.Value = valueNormalised;
            }
            
            lblStatusMessage.Text = message;
        }
    }
}

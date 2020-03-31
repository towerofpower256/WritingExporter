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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openWDCReaderTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var testerForm = new WdcReaderTesterForm();
            testerForm.ShowDialog(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WritingExporter.WinForms.WdcTester.FormControls
{
    public partial class EasyFieldControl : UserControl
    {
        public EasyFieldControl()
        {
            InitializeComponent();
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        public string Label
        {
            get { return lblLabel.Text; }
            set { lblLabel.Text = value; }
        }
    }
}

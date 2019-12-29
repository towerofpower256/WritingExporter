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
    public partial class MyTextFieldWithTickbox : UserControl
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get { return this._Text; }
            set { this._Text = value; if (this.Title != null) this.Title.Text = value; }
        }
		
		private string _Text;


        public MyTextFieldWithTickbox()
        {
            InitializeComponent();
        }


    }
}

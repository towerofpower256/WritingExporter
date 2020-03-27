using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WritingExporter.Common.Events;
using WritingExporter.Common.Logging;

namespace WritingExporter.WinForms.Forms
{
    public partial class MainForm : Form
    {
        ILogger _log;
        EventHub _eventHub;

        public MainForm(ILoggerSource logSource, EventHub eventHub)
        {
            _log = logSource.GetLogger(typeof(MainForm));
            _eventHub = eventHub;

            InitializeComponent();
        }
    }
}

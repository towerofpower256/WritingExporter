using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WritingExporter.Common.Logging;
using WritingExporter.Common.Models;
using WritingExporter.Common.Events;
using WritingExporter.Common.Exceptions;
using WritingExporter.Common;
using WritingExporter.Common.WDC;
using WritingExporter.Common.Configuration;

namespace WritingExporter.WinForms.WdcTester.Forms
{
    public partial class MainForm : Form
    {
        // Services
        ILogger _log;
        WdcReader _wdcReader;
        IConfigProvider _configProvider;

        public MainForm(ILoggerSource logSource, WdcReader wdcReader, IConfigProvider configProvider)
        {
            _log = logSource.GetLogger(typeof(MainForm));
            _log.Debug("Main form starting");

            _wdcReader = wdcReader;
            _configProvider = configProvider;

            InitializeComponent();
        }

        private void ReadInputToStory()
        {
            LockInput(true);
            txtOutput.Clear();
            StringBuilder sbOutput = new StringBuilder();
            try
            {
                sbOutput.AppendLine("Reading WDC story from content input");

                var content = txtInputContent.Text;
                WdcInteractiveStory story = _wdcReader.GetInteractiveStory("TEST", new WdcPayload() { Source = "", Payload = content });

                sbOutput.AppendLine($"ID: {story.ID}");
                sbOutput.AppendLine($"Name: {story.Name}");
                sbOutput.AppendLine($"Author name: {story.Author.Name}");
                sbOutput.AppendLine($"Author username: {story.Author.Username}");
                sbOutput.AppendLine($"Short description: {story.ShortDescription}");
                sbOutput.AppendLine($"Description: {story.Description}");
            }
            catch (Exception ex)
            {
                sbOutput.AppendLine("An exception has occurred!");
                sbOutput.AppendLine(ex.GetType().FullName);
                sbOutput.AppendLine(ex.Message);
            }
            finally
            {
                txtOutput.Text = sbOutput.ToString();
                LockInput(false);
            }
        }

        private void SyncFormToSettings()
        {
            var config = _configProvider.GetSection<WdcReaderConfiguration>();
        }

        private void SyncSettingsToForm()
        {
            var config = _configProvider.GetSection<WdcReaderConfiguration>();

            
        }

        #region Form update functions

        private void LockInput(bool locked)
        {
            txtInputContent.ReadOnly = locked;

            btnWdcReadToStory.Enabled = !locked;
        }

        private delegate void UpdateInputContentDelegate(string content);
        public void UpdateInputContent(string content)
        {
            if (txtInputContent.InvokeRequired)
            {
                new UpdateInputContentDelegate(UpdateInputContent).Invoke(content);
                return;
            }

            txtInputContent.Text = content;
        }

        #endregion

        #region EventHanding

        private void btnWdcReadToStory_Click(object sender, EventArgs e)
        {
            ReadInputToStory();
        }

        #endregion


    }
}

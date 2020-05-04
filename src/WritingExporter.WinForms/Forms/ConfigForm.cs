using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WritingExporter.Common.Configuration;

namespace WritingExporter.WinForms.Forms
{
    public partial class ConfigForm : Form
    {
        const string PASSWORD_PLACEHOLDER = "******";

        ConfigService _config;

        public ConfigForm(ConfigService config)
        {
            _config = config;

            InitializeComponent();

            LoadSettings();
        }

        void LoadSettings()
        {
            var wdcClientConfig = _config.GetSection<WdcClientConfigSection>();

            txtWdcUsername.Text = wdcClientConfig.WritingUsername;
            //txtWdcPassword.Text = wdcClientConfig.WritingPassword;
            txtWdcPassword.Text = PASSWORD_PLACEHOLDER;
        }

        void SaveSettings()
        {

            var wdcClientConfig = _config.GetSection<WdcClientConfigSection>();
            wdcClientConfig.WritingUsername = txtWdcUsername.Text;
            if (txtWdcPassword.Text != PASSWORD_PLACEHOLDER) wdcClientConfig.WritingPassword = txtWdcPassword.Text;
            _config.SetSection(wdcClientConfig);

            _config.SaveSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

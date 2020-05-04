using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WritingExporter.Common.Data.Repositories;
using WritingExporter.Common.Models;
using WritingExporter.Common.Wdc;
using System.Threading;

namespace WritingExporter.WinForms.Forms
{
    public partial class AddStoryForm : Form
    {
        WdcStoryRepository _storyRepo;
        WdcClient _wdcClient;
        WdcReaderFactory _wdcReaderFactory;

        WdcStory _story;

        public AddStoryForm(WdcStoryRepository storyRepo, WdcClient wdcClient, WdcReaderFactory wdcReaderFactory)
        {
            _storyRepo = storyRepo;
            _wdcClient = wdcClient;
            _wdcReaderFactory = wdcReaderFactory;

            InitializeComponent();

            EnableSave(false);
        }

        void EnableGet(bool a)
        {
            btnGetStory.Enabled = a;
        }

        void EnableSave(bool a)
        {
            btnAddStory.Enabled = a;
        }

        async void GetStory()
        {
            var sb = new StringBuilder();
            _story = null;

            try
            {
                EnableGet(false);
                EnableSave(false);

                var reader = _wdcReaderFactory.GetReader();

                var storyUrl = new Uri(txtStoryUrl.Text);
                var htmlPayload = await _wdcClient.GetWdcPage(storyUrl, new CancellationToken());
                var story = reader.GetInteractiveStory(htmlPayload, WdcUtil.GetFinalParmFromUrl(storyUrl), storyUrl.ToString());

                sb.AppendLine("Story name:");
                sb.AppendLine(story.Name);
                sb.AppendLine();
                sb.AppendLine("Short description:");
                sb.AppendLine(story.ShortDescription);
                sb.AppendLine();
                sb.AppendLine(story.Description);

                _story = story;

                EnableSave(true);
            }
            catch (Exception ex)
            {
                sb.AppendLine(ex.GetType().ToString());
                sb.AppendLine(ex.Message);
            }
            finally
            {
                txtStoryInfo.Text = sb.ToString();
                EnableGet(true);
            }
            
        }

        void SaveStory()
        {
            if (_story != null)
            {
                try
                {
                    _storyRepo.Add(_story);

                    this.Close();
                }
                catch (Exception ex)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Exception encountered while trying to add the story");
                    sb.AppendLine();
                    sb.AppendLine(ex.GetType().ToString());
                    sb.AppendLine(ex.Message);
                    MessageBox.Show(sb.ToString(), "Exception trying to add story", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGetStory_Click(object sender, EventArgs e)
        {
            GetStory();
        }

        private void btnAddStory_Click(object sender, EventArgs e)
        {
            SaveStory();
        }
    }
}

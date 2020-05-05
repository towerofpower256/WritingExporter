using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Models;

namespace WritingExporter.WinForms.Models
{
    public class WdcStoryListViewModel
    {
        public WdcStory Story { get; set; }

        public int ChapterCountTotal { get; set; }

        public int ChapterCountReady { get; set; }

        public DateTime RecentChapter { get; set; }

        public string StoryStateLabel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Models;

namespace WritingExporter.WinForms.Models
{
    public class WdcStoryListViewModel
    {
        public WdcStory Story { get; set; }

        public string Name { get; set; }

        public string SysId { get; set; }

        public string State { get; set; }

        public string StateMessage { get; set; }

        public string StateDisplay { get; set; }

        public Color StateColor { get; set; } = Color.Empty;

        public string ChaptersDisplay { get; set; }

        public int ChapterCountTotal { get; set; }

        public int ChapterCountReady { get; set; }

        public string LastSynced { get; set; }

        public string NextSync { get; set; }

        public string LastUpdatedInfo { get; set; }

        public string LastUpdatedChapterOutline { get; set; }

        public string LastChapterUpdated { get; set; }
    }
}

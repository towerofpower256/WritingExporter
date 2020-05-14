using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Models
{
    public class WdcChapterOutline
    {
        public string SysId { get; set; }

        public string StoryId { get; set; }

        public string Path { get; set; }

        public string Title { get; set; }

        public DateTime LastSynced { get; set; }

        public DateTime LastUpdated { get; set; }

        public DateTime FirstSeen { get; set; }
    }
}

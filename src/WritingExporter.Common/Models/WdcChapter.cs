using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Models
{
    [Serializable]
    public class WdcChapter
    {
        public string SysId { get; set; } = Guid.NewGuid().ToString("N");

        public string StoryId { get; set; }

        public string Path { get; set; }

        public string Title { get; set; }

        public string SourceChoiceTitle { get; set; } // Yes, we will to save this, because sometimes it's different from the title

        public WdcAuthor Author { get; set; } // The author, not sure if it changes with edits

        public string Content { get; set; } // The content / writing of the chapter, the flesh of it

        public bool IsEnd { get; set; } = false; // Is this chapter a dead end in the story tree

        public DateTime LastUpdated { get; set; }

        public DateTime FirstSeen { get; set; }
    }
}

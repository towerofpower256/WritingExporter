using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WritingExporter.Common.Models
{
    [Serializable]
    public class WdcStory
    {
        [XmlIgnore]
        public string SysId { get; set; } = SysUtil.GenerateGuidString();

        public string Name { get; set; } // E.g. Short stories by the people

        public string Id { get; set; } // E.g. 1824771-short-stories-by-the-people

        public string Url { get; set; } // E.g. https://www.writing.com/main/interact/item_id/1824771-short-stories-by-the-people

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string AuthorName { get; set; } // The author, not sure if it changes with edits

        public string AuthorUsername { get; set; } // The author, not sure if it changes with edits

        public DateTime LastSynced { get; set; } // When the sync worker last looked at this story.

        public DateTime NextSync { get; set; } // When the sync worker should look at this next.

        public DateTime LastUpdatedInfo { get; set; } // When the last scrape update was run against Writing.com for the story's info

        public DateTime LastUpdatedChapterOutline { get; set; } // When the last scape was run against Writing.com for the chapter outline

        public DateTime FirstSeen { get; set; }

        public WdcStoryState State { get; set; }

        public string StateMessage { get; set; }
    }

    public enum WdcStoryState
    {
        Idle,
        IdleItuPause,
        Syncing,
        Disabled,
        Error
    }
}

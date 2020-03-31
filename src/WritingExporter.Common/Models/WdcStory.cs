using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Models
{
    [Serializable]
    public class WdcStory
    {
        public string SysId { get; set; } = Guid.NewGuid().ToString("N");

        public string Name { get; set; } // E.g. Short stories by the people

        public string Id { get; set; } // E.g. 1824771-short-stories-by-the-people

        public string Url { get; set; } // E.g. https://www.writing.com/main/interact/item_id/1824771-short-stories-by-the-people

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Author { get; set; } // E.g. That Guy (thatguy)

        public DateTime LastUpdatedInfo { get; set; } // When the last scrape update was run against Writing.com for the story's info

        public DateTime LastUpdatedChapterOutline { get; set; } // When the last scape was run against Writing.com for the chapter outline

        public DateTime FirstSeen { get; set; }

        public WdcStoryState State { get; set; }

        public string StateMessage { get; set; }
    }

    public enum WdcStoryState
    {
        Idle,
        Syncing,
        Disabled,
        Error
    }
}

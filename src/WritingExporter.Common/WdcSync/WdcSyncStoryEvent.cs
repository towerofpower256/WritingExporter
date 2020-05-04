using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Events;

namespace WritingExporter.Common.WdcSync
{
    public class WdcSyncStoryEvent : IEvent
    {
        public string StorySysId { get; set; }

        public string StoryLabel { get; set; }

        public WdcSyncStoryEventType EventType { get; set; }

        public string Message { get; set; }

        public WdcSyncStoryEvent(WdcSyncStoryEventType eventType, string storySysId, string storyLabel, string message)
        {
            StorySysId = storySysId;
            StoryLabel = storyLabel;
            EventType = eventType;
            Message = message;
        }
    }

    public enum WdcSyncStoryEventType
    {
        StorySyncStarted,
        StorySyncComplete,
        StorySyncIncomplete,
        StorySyncException,
    }
}

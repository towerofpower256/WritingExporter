using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Events;

namespace WritingExporter.Common.WdcSync
{
    public class WdcSyncWorkerCommandEvent : IEvent
    {
        public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

        public WdcSyncWorkerCommandEventType CommandType { get; set; }

        public WdcSyncWorkerCommandEvent(WdcSyncWorkerCommandEventType commandType)
        {
            CommandType = commandType;
        }
    }

    public enum WdcSyncWorkerCommandEventType
    {
        RequestStatusUpdate,
        StartWorker,
        StopWorker,
        SyncStoryNow,
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Events;

namespace WritingExporter.Common.WdcSync
{
    public class WdcSyncWorkerCommandEvent : IEvent
    {
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
    }
}

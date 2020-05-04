using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Events;

namespace WritingExporter.Common.WdcSync
{
    public class WdcSyncWorkerEvent : IEvent
    {
        public WdcSyncWorkerStatus Status { get; set; }

        public WdcSyncWorkerEvent(WdcSyncWorkerStatus status)
        {
            Status = status;
        }
    }
}

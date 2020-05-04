using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.WdcSync
{
    [Serializable]
    public class WdcSyncWorkerStatus
    {
        public WdcSyncWorkerState State { get; set; }

        public string CurrentTask { get; set; }

        public string Message { get; set; }
    }

    public enum WdcSyncWorkerState
    {
        WorkerIdle,
        WorkerWorking,
        WorkerError,
    }
}

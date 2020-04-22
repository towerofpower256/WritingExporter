using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Models
{
    public class WdcStorySyncStatus
    {
        public string SysId { get; set; }

        public string SyncMessage { get; set; }

        public WdcStorySyncState SyncState { get; set; }

        public DateTime LastUpdatedOn { get; set; }
    }

    public enum WdcStorySyncState
    {
        Idle,
        Syncing,
        Error,
    }
}

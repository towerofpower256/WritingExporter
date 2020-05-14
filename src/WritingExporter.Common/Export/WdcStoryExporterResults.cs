using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Export
{
    public class WdcStoryExporterResults
    {
        public WdcStoryExporterResultsState State { get; set; }

        public string StorySysId { get; set; }

        public object Sender { get; set; }

        public string PathToExport { get; set; }

        public Exception Exception { get; set; }

        public WdcStoryExporterResults(object sender, string storySysId, WdcStoryExporterResultsState state, string pathToExport, Exception exception)
        {
            Sender = sender;
            StorySysId = storySysId;
            State = state;
            PathToExport = pathToExport;
            Exception = exception;
        }
    }

    public enum WdcStoryExporterResultsState
    {
        Completed,
        Exception,
        Cancelled
    }
}

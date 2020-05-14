using System;

namespace WritingExporter.Common.Export
{
    public class WdcStoryExporterProgressUpdateArgs
    {
        public object Sender { get; set; }

        public int ProgressValue { get; set; }

        public int ProgressMax { get; set; }

        public string Message { get; set; }

        public WdcStoryExporterProgressUpdateState State;

        public Exception Exception { get; set; }
    }

    public enum WdcStoryExporterProgressUpdateState
    {
        Working,
        Completed,
        Error,
        Cancelled
    }
}
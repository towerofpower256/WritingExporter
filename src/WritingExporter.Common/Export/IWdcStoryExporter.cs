using System;

namespace WritingExporter.Common.Export
{
    public interface IWdcStoryExporter
    {
        event EventHandler<WdcStoryExporterProgressUpdateArgs> OnProgressUpdate;

        WdcStoryExporterResults ExportStory(string storySysid, string outputDir);

        void Cancel();

        string GetHomepageFileName();

        string GetOutlineFileName();

        string GetRecentChaptersFileName();
    }
}
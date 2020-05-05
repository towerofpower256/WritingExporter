using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Logging;

namespace WritingExporter.Common.File_Dumper
{
    public class FileDumperService
    {
        const string OUTPUT_DIR = "Dump";

        ILogger _log;
        object _dumpLock = new object();

        public FileDumperService(ILoggerSource loggerSource)
        {
            _log = loggerSource.GetLogger(typeof(FileDumperService));
        }

        public FileDumperResult DumpFile(string filename, string content)
        {
            lock (_dumpLock)
            {
                string filePath = string.Empty;
                try
                {
                    filePath = Path.Combine(OUTPUT_DIR, filename);
                    _log.Debug($"Dumping file: {filePath}");

                    if (!Directory.Exists(OUTPUT_DIR)) Directory.CreateDirectory(OUTPUT_DIR);

                    File.WriteAllText(filePath, content);

                    return new FileDumperResult(true, filePath);
                }
                catch (Exception ex)
                {
                    _log.Error($"Error while trying to dump file to {filePath}", ex);

                    throw ex;
                }
            }
        }

        public string GetTimestampForPath(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH-mm-ss");
        }
    }
}

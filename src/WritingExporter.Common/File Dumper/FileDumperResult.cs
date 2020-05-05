using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.File_Dumper
{
    public class FileDumperResult
    {
        public bool Success { get; set; }

        public string Filename { get; set; }

        public FileDumperResult(bool success, string filename)
        {
            Success = success;
            Filename = filename;
        }
    }
}

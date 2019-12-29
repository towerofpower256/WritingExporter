using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.WDC
{
    public class WdcPayload
    {
        public string Source { get; set; }
        public string Payload { get; set; }

        public WdcPayload() { }

        public WdcPayload(string source, string payload)
        {
            Source = source;
            Payload = payload;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Exceptions
{
    public class WdcReaderHtmlParseException : Exception
    {
        public WdcReaderHtmlParseException() : base() { }

        public WdcReaderHtmlParseException(string message) : base(message) { }

        public WdcReaderHtmlParseException(string message, string htmlPayload) : base(message) {
            Data.Add("HtmlPayload", htmlPayload);
        }
    }
}

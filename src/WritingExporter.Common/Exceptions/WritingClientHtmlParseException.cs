using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Exceptions
{
    public class WritingClientHtmlParseException : Exception
    {
        public WritingClientHtmlParseException() : base() { }

        public WritingClientHtmlParseException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Exceptions
{
    public class WdcMissingCredentialsException : Exception
    {
        public WdcMissingCredentialsException() : base() { }

        public WdcMissingCredentialsException(string message) : base(message) { }
    }
}

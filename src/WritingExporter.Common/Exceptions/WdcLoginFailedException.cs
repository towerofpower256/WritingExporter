using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Exceptions
{
    public class WdcLoginFailedException : Exception
    {
        public WdcLoginFailedException()
        { }

        public WdcLoginFailedException(string message)
            : base(message)
        { }

        public WdcLoginFailedException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}

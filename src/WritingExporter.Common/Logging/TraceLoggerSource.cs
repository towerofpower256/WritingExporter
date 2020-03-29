using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Logging
{
    public class TraceLoggerSource : ILoggerSource
    {
        public ILogger GetLogger(string loggerName)
        {
            if (string.IsNullOrEmpty(loggerName))
                throw new ArgumentNullException("loggerName");

            return new TraceLogger(loggerName);
        }

        public ILogger GetLogger(Type loggerType)
        {
            return GetLogger(loggerType.Name);
        }
    }
}

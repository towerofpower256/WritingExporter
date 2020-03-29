using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Logging
{
    public class BlankLogger : ILogger
    {
        public void Debug(object message) { }

        public void Debug(object message, Exception exception) { }

        public void DebugFormat(string format, params object[] parms) { }

        public void Error(object message) { }

        public void Error(object message, Exception exception) { }

        public void ErrorFormat(string format, params object[] parms) { }

        public void Fatal(object message) { }

        public void Fatal(object message, Exception exception) { }

        public void FatalFormat(string format, params object[] parms) { }

        public void Info(object message) { }

        public void Info(object message, Exception exception) { }

        public void InfoFormat(string format, params object[] parms) { }

        public void Warn(object message) { }

        public void Warn(object message, Exception exception) { }

        public void WarnFormat(string format, params object[] parms) { }
    }
}

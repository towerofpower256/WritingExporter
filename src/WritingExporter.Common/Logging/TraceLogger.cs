using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Logging
{
    // Trace logger, for use when there is not a fully fleshed logging solution avalilable, but you still want to log stuff.
    public class TraceLogger : ILogger
    {
        string _name;

        public TraceLogger(string loggerName)
        {
            _name = loggerName;
        }

        public void Debug(object message)
        {
            DoTrace("DEBUG", message);
        }

        public void Debug(object message, Exception exception)
        {
            DoTrace("DEBUG", message, exception);
        }

        public void DebugFormat(string format, params object[] parms)
        {
            DoTrace("DEBUG", format, parms);
        }

        public void Error(object message)
        {
            DoTrace("ERROR", message);
        }

        public void Error(object message, Exception exception)
        {
            DoTrace("ERROR", message, exception);
        }

        public void ErrorFormat(string format, params object[] parms)
        {
            DoTrace("ERROR", format, parms);
        }

        public void Fatal(object message)
        {
            DoTrace("FATAL", message);
        }

        public void Fatal(object message, Exception exception)
        {
            DoTrace("FATAL", message, exception);
        }

        public void FatalFormat(string format, params object[] parms)
        {
            DoTrace("FATAL", format, parms);
        }

        public void Info(object message)
        {
            DoTrace("INFO", message);
        }

        public void Info(object message, Exception exception)
        {
            DoTrace("INFO", message, exception);
        }

        public void InfoFormat(string format, params object[] parms)
        {
            DoTrace("INFO", format, parms);
        }

        public void Warn(object message)
        {
            DoTrace("WARN", message);
        }

        public void Warn(object message, Exception exception)
        {
            DoTrace("WARN", message, exception);
        }

        public void WarnFormat(string format, params object[] parms)
        {
            DoTrace("WARN", format, parms);
        }

        public void DoTrace(string level, object message)
        {
            Trace.WriteLine($"[{level}][{_name}]: {message.ToString()}");
        }

        public void DoTrace(string level, object message, params object[] parms)
        {
            Trace.WriteLine($"[{level}][{_name}]: {string.Format(message.ToString(), parms)}");
        }

        public void DoTrace(string level, object message, Exception exception)
        {
            Trace.WriteLine($"[{level}][{_name}]: {message.ToString()}\n{ReadException(exception)}");
        }

        public string ReadException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ex.GetType().FullName);
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);

            return sb.ToString();
        }
    }
}

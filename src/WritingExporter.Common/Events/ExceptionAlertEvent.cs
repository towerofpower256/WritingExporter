using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Events
{
    public class ExceptionAlertEvent : IEvent
    {
        public readonly Exception Exception;
        public readonly object Sender;
        public readonly string Message;

        public ExceptionAlertEvent(object sender, Exception exception, string message)
        {
            Exception = exception;
            Sender = sender;
            Message = message;
        }
    }
}

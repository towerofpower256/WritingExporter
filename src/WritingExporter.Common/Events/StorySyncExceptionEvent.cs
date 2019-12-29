using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Events
{
    public class StorySyncExceptionEvent : IEvent
    {
        public string Message { get; private set; }

        public string Title { get; private set; }

        public StorySyncExceptionEvent(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}

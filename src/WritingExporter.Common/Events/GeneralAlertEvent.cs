using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Events
{
    public class GeneralAlertEvent : IEvent
    {
        public GeneralAlertEventType AlertType { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public GeneralAlertEvent(GeneralAlertEventType alertType, string title, string message)
        {
            AlertType = alertType;
            Title = title;
            Message = message;
        }
    }

    public enum GeneralAlertEventType
    {
        Information,
        Question,
        Warning,
        Error
    }
}

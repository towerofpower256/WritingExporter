using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Events;
using WritingExporter.Common.Logging;
using WritingExporter.WinForms.Forms;

namespace WritingExporter.WinForms
{
    public class ExceptionAlertListener : IEventSubscriber<ExceptionAlertEvent>
    {
        ILogger _log;

        public ExceptionAlertListener()
        {

        }

        public Task HandleEventAsync(ExceptionAlertEvent @event)
        {
            var form = new ExceptionDialogForm();
            form.SetInfo(@event.Message, @event.Exception);
            form.Show();

            return Task.CompletedTask;
        }
    }
}

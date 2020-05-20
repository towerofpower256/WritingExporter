using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WritingExporter.Common.Events;
using WritingExporter.Common.Logging;
using WritingExporter.WinForms.Forms;

namespace WritingExporter.WinForms
{
    public class AlertListener : IEventSubscriber<ExceptionAlertEvent>, IEventSubscriber<GeneralAlertEvent>
    {
        ILogger _log;

        public AlertListener()
        {

        }

        public Task HandleEventAsync(ExceptionAlertEvent @event)
        {
            var form = new ExceptionDialogForm();
            form.SetInfo(@event.Message, @event.Exception);
            form.ShowDialog();

            return Task.CompletedTask;
        }

        public Task HandleEventAsync(GeneralAlertEvent @event)
        {
            MessageBoxIcon icon = MessageBoxIcon.Information;
            switch (@event.AlertType)
            {
                case GeneralAlertEventType.Information:
                    icon = MessageBoxIcon.Information;
                    break;
                case GeneralAlertEventType.Question:
                    icon = MessageBoxIcon.Question;
                    break;
                case GeneralAlertEventType.Warning:
                    icon = MessageBoxIcon.Warning;
                    break;
                case GeneralAlertEventType.Error:
                    icon = MessageBoxIcon.Error;
                    break;
            }

            MessageBox.Show(@event.Message, @event.Title, MessageBoxButtons.OK, icon);

            return Task.CompletedTask;
        }
    }
}

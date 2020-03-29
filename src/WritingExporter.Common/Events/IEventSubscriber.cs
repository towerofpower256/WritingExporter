using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Events
{
    public interface IEventSubscriber<TEvent> where TEvent : IEvent
    {
        Task HandleEventAsync(TEvent @event);
    }
}

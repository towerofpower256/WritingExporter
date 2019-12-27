using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WritingExporter.Common.Events
{
    public class EventHub
    {
        Dictionary<Type, EventSubscriptionCollection> _subs;
        object _lock = new object();
        ILogger _log;

        public EventHub(ILogger log)
        {
            _log = log;
            _subs = new Dictionary<Type, EventSubscriptionCollection>();
        }

        public void UnsubscribeAll(object subscriber)
        {
            lock (_lock)
            {
                foreach (var v in _subs)
                {
                    var subCol = v.Value;
                    foreach (var subscription in subCol.FindAll((s) => !s.IsUnsubscribed && s.Reference.Target == subscriber))
                    {
                        subscription.Unsubscribe();
                    }

                    subCol.Cleanup();
                }
            }
        }

        public void Unsubscribe<TEvent>(IEventSubscriber<TEvent> subscriber) where TEvent : IEvent
        {
            lock (_lock)
            {
                EventSubscriptionCollection subCol;
                if (_subs.TryGetValue(typeof(TEvent), out subCol))
                {
                    foreach (var subscription in subCol.FindAll((s) => s.Reference.Target == subscriber))
                    {
                        subscription.Unsubscribe();
                    }

                    subCol.Cleanup();
                }
            }
        }

        public EventSubscription Subscribe<TEvent>(IEventSubscriber<TEvent> subscriber) where TEvent : IEvent
        {
            lock (_lock)
            {
                // If there isn't already a subscription collection for this type of event, create it.
                EventSubscriptionCollection subCol;
                if (!_subs.TryGetValue(typeof(TEvent), out subCol))
                {
                    subCol = new EventSubscriptionCollection();
                    _subs.Add(typeof(TEvent), subCol);
                }

                // Create the event subscription
                // and add it to the collection.
                var newSub = new EventSubscription(subscriber);
                subCol.Add(newSub);

                return newSub;
            }
        }

        public void PublishEvent<TEvent>(TEvent @event, bool runAsync = true) where TEvent : IEvent
        {
            lock (_lock)
            {
                EventSubscriptionCollection subCol;
                if (_subs.TryGetValue(typeof(TEvent), out subCol))
                {
                    foreach (var subscription in subCol)
                    {
                        if (!subscription.Reference.IsAlive) return;
                        if (subscription.IsUnsubscribed) return;

                        var publishTask = new Task(() => ((IEventSubscriber<TEvent>)subscription.Reference.Target).HandleEventAsync(@event));
                        if (runAsync) publishTask.Start();
                        else publishTask.RunSynchronously();
                    }

                    subCol.Cleanup();
                }
            }
        }
    }

    public class EventSubscriptionCollection : List<EventSubscription>
    {
        public void Cleanup()
        {
            // Cleanup some old / stale subscriptions
            this.RemoveAll((s) => s.IsUnsubscribed || !s.Reference.IsAlive);
        }
    }

    public class EventSubscription
    {
        public WeakReference Reference { get; set; }
        public bool IsUnsubscribed { get; private set; } = false;

        public EventSubscription(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            Reference = new WeakReference(obj);
        }

        public void Unsubscribe()
        {
            IsUnsubscribed = true;
        }
    }
}

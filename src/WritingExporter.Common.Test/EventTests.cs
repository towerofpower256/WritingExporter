using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using WritingExporter.Common.Events;
using WritingExporter.Common.Logging;

namespace WritingExporter.Common.Test
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void Instantiation()
        {
            var eh = new EventHub(GetLogger());
        }

        [TestMethod]
        public void SimpleEventAndReview()
        {
            var testValue = "testing-abc";

            var eh = new EventHub(GetLogger());
            var testSubscriber = new TestEventSubscriber();
            eh.Subscribe<TestEvent1>(testSubscriber);

            eh.PublishEvent(new TestEvent1(testValue), runAsync: false);

            Assert.AreEqual(testValue, testSubscriber.LastMessage);
        }

        [TestMethod]
        public void RapidFireEvents()
        {
            var eh = new EventHub(GetLogger());

            List<SlowEventSubscriber> _subscribers = new List<SlowEventSubscriber>();
            for (var i = 0; i < 10; i++)
            {
                var newSub = new SlowEventSubscriber();
                eh.Subscribe<TestEvent1>(newSub);
                _subscribers.Add(newSub);
            }

            // Do it
            for (var i = 0; i < 100; i++)
            {
                eh.PublishEvent(new TestEvent1("testing"));
            }
        }

        [TestMethod]
        public void GarbageCollectionSafety()
        {
            var eh = new EventHub(GetLogger());
            var obj = new TestEventSubscriber();
            var objRef = new WeakReference(obj);

            Assert.IsTrue(objRef.IsAlive);

            // Cleanup listener
            eh.Subscribe<TestEvent1>(obj);
            obj = null;
            GC.Collect();

            // Check if subscription acknowledges that subscriber has been garbage collected
            Assert.IsFalse(objRef.IsAlive, "Test subscriber is still alive after garbage collection.");

            // Publish some events, shouldn't throw any exceptions
            eh.PublishEvent(new TestEvent1("testing1"), runAsync: false);
            eh.PublishEvent(new TestEvent1("testing2"), runAsync: false);
            eh.PublishEvent(new TestEvent1("testing3"), runAsync: false);

            // Made it out here, didn't throw any exceptions
        }

        [TestMethod]
        public void TestUnsubscribe()
        {
            var eh = new EventHub(GetLogger());
            var sub1 = new TestEventSubscriber(); eh.Subscribe<TestEvent1>(sub1);
            var sub2 = new TestEventSubscriber(); eh.Subscribe<TestEvent1>(sub2);

            var testValue1 = "Test1";
            eh.PublishEvent(new TestEvent1(testValue1), runAsync: false);
            // Both subscribers are subscribed, and should be the same as the test value
            Assert.AreEqual(testValue1, sub1.LastMessage);
            Assert.AreEqual(testValue1, sub2.LastMessage);

            eh.UnsubscribeAll(sub2);

            var testValue2 = "Test2";
            eh.PublishEvent(new TestEvent1(testValue2), runAsync: false);
            Assert.AreEqual(testValue2, sub1.LastMessage); // Sub1 should have changed, because it's still subscribed
            Assert.AreEqual(testValue1, sub2.LastMessage); // Sub2 should NOT have changed, because it unsubscribed
        }

        [TestMethod]
        public void SubscriberToMultipleEvents()
        {
            var eh = new EventHub(GetLogger());
            var sub = new MultiEventSubscriber();
            eh.Subscribe<TestEvent1>(sub);
            eh.Subscribe<TestEvent2>(sub);

            var testValue1 = "Test1";
            eh.PublishEvent(new TestEvent1(testValue1), runAsync: false);
            Assert.AreEqual(testValue1, sub.LastMessage);

            var testValue2 = "Test2";
            eh.PublishEvent(new TestEvent2(testValue2), runAsync: false);
            Assert.AreEqual(testValue2, sub.LastMessage);
        }

        private static ILogger GetLogger()
        {
            return new TraceLogger();
        }
    }

    public class TestEvent1 : IEvent
    {
        public readonly string Message;

        public TestEvent1(string message)
        {
            Message = message;
        }
    }

    public class TestEvent2 : IEvent
    {
        public readonly string Message;

        public TestEvent2(string message)
        {
            Message = message;
        }
    }

    public class TestEventSubscriber : IEventSubscriber<TestEvent1>
    {
        public string LastMessage = "";

        public Task HandleEventAsync(TestEvent1 @event)
        {
            LastMessage = @event.Message;

            return Task.CompletedTask;
        }
    }

    public class SlowEventSubscriber : IEventSubscriber<TestEvent1>
    {
        public string LastMessage = "";

        public Task HandleEventAsync(TestEvent1 @event)
        {
            Thread.Sleep(5000);

            LastMessage = @event.Message;

            return Task.CompletedTask;
        }
    }

    public class MultiEventSubscriber : IEventSubscriber<TestEvent1>, IEventSubscriber<TestEvent2>
    {
        public string LastMessage = "";

        public Task HandleEventAsync(TestEvent1 @event)
        {
            LastMessage = @event.Message;
            return Task.CompletedTask;
        }

        public Task HandleEventAsync(TestEvent2 @event)
        {
            LastMessage = @event.Message;
            return Task.CompletedTask;
        }
    }
}

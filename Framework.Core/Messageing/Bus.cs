using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Messageing
{
    public class Bus : IApplicationBus
    {
        private List<object> _subscribers;
        public Bus()
        {
            _subscribers = new List<object>();
        }
        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlers = _subscribers.OfType<IEventHandler<TEvent>>().ToList();
            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }

        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            _subscribers.Add(eventHandler);
        }
    }
}

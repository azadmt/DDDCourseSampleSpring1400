using System;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Messageing
{
    public interface IApplicationBus
    {
        void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }

    public interface IEnterpriseServiceBus
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent;

    }
}

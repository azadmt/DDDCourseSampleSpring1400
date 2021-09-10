using Framework.Core.Messageing;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Framework.Messaging.MassTransit
{
    public class MassTransitBus : IEnterpriseServiceBus
    {
        private readonly IBusControl busControl;

        public MassTransitBus(IBusControl busControl)
        {
            this.busControl = busControl;
        }
        public void Publish<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        {
            throw new NotImplementedException();
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        {
            await busControl.Publish(@event);
        }
    }
}

using System;

namespace Framework.Core.Messageing
{
    public interface IEvent
    {

    }

    public interface IIntegrationEvent
    {

    }

    public class OutboxMessage
    {
        public Guid Id { get; set; }
        public string MessageContent{ get; set; }
        public string MessageType{ get; set; }
        public bool IsPublished{ get; set; }
    }
}

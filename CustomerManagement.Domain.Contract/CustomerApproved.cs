using Framework.Core.Messageing;
using System;

namespace CustomerManagement.Domain.Contract
{
    public class CustomerApproved : IEvent, IIntegrationEvent
    {
        public CustomerApproved(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

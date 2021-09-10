using Framework.Core.Messageing;
using System;

namespace LoanManagement.Domain.Contract
{
    public class LoanApproved : IEvent
    {
        public LoanApproved(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

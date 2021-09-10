using Framework.Core.Messageing;
using System;

namespace LoanManagement.Domain.Contract
{
    public class LoanRejected : IEvent
    {
        public LoanRejected(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

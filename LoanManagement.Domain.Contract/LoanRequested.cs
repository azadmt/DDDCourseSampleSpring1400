using Framework.Core.Messageing;
using System;

namespace LoanManagement.Domain.Contract
{
    public class LoanRequested : IEvent
    {
        public LoanRequested(Guid id, Guid ownerId, Guid loanTypeId, decimal loanAmount)
        {
            Id = id;
            OwnerId = ownerId;
            LoanTypeId = loanTypeId;
            LoanAmount = loanAmount;
        }

        public Guid Id { get; }
        public Guid OwnerId { get; }
        public Guid LoanTypeId { get; }
        public decimal LoanAmount { get; }
    }
}

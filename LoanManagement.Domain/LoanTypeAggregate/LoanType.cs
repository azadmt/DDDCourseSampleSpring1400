using Framework.Domain;
using LoanManagement.Domain.Contract;
using System;

namespace LoanManagement.Domain.LoanTypeAggregate
{
    public class LoanType : AggregateRoot
    {
        public string Title { get; }
        public int Code { get; }
        public int PayDuration { get; }
        private LoanType()
        {

        }
        public LoanType(Guid id, string title, int code, int payDuration) : base(id)
        {
            Title = title;
            Code = code;
            PayDuration = payDuration;
            AddChanges(new LoanTypeCreated(id, Title, Code, PayDuration));
        }

    }

}
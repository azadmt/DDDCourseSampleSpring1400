using Framework.Domain;
using System;

namespace LoanManagement.Domain.LoanTypeAggregate
{
    public class LoanType : Entity
    {

        public string Title { get; }
        public int Code { get; }
        public int PayDuration { get; }
        private LoanType()
        {

        }
        public LoanType(Guid id, string title, int code, int payDateDay) : base(id)
        {

            Title = title;
            Code = code;
            PayDuration = payDateDay;
        }

    }

}
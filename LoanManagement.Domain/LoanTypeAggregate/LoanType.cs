using Framework.Domain;
using System;

namespace LoanManagement.Domain.LoanTypeAggregate
{
    public class LoanType : Entity
    {

        public string Title { get; }
        public int Code { get; }
        public int InstallmentCount { get; }
        public int PayDateDay { get; }

        public LoanType(Guid id, string title, int code, int installmentCount, int payDateDay) : base(id)
        {

            Title = title;
            Code = code;
            InstallmentCount = installmentCount;
            PayDateDay = payDateDay;
        }

    }

}
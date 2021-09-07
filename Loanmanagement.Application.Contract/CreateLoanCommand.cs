using Framework.Application;
using System;

namespace Loanmanagement.Application.Contract
{
    public class CreateLoanCommand : ICommand
    {
        public Guid OwnerId { get; set; }
        public Guid LoanTypeId { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime PayDate { get; set; }
    }
}

using Framework.Application;
using System;

namespace Loanmanagement.Application.Contract
{
    public class PayLoanCommand: ICommand
    {
        public Guid LoanId { get; set; }
    }
}

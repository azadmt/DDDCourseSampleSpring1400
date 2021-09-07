using Framework.Application;
using System;

namespace Loanmanagement.Application.Contract
{
    public class ApproveLoanCommand: ICommand
    {
        public Guid LoanId { get; set; }
    }
}

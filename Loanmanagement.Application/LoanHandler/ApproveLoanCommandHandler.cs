using Framework.Application;
using Loanmanagement.Application.Contract;
using LoanManagement.Domain.LoanAggregate;
using System;

namespace Loanmanagement.Application.LoanHandler
{
    public class ApproveLoanCommandHandler : ICommandHandler<ApproveLoanCommand>
    {
        private readonly ILoanRepository loanRepository;

        public ApproveLoanCommandHandler(ILoanRepository loanRepository)
        {
            this.loanRepository = loanRepository;
        }
        public void Handle(ApproveLoanCommand command)
        {
            var loan = loanRepository.Get(command.LoanId);
            loan.Approve();
            loanRepository.Update(loan);
        }
    }
}

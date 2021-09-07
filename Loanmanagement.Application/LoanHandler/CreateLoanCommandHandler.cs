using Framework.Application;
using Loanmanagement.Application.Contract;
using LoanManagement.Domain.LoanAggregate;
using LoanManagement.Domain.LoanTypeAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loanmanagement.Application.LoanHandler
{
    public class CreateLoanCommandHandler : ICommandHandler<CreateLoanCommand>
    {
        private readonly ILoanRepository loanRepository;
        private readonly ILoanTypeRepository loanTypeRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository, ILoanTypeRepository loanTypeRepository)
        {
            this.loanRepository = loanRepository;
            this.loanTypeRepository = loanTypeRepository;
        }

        public void Handle(CreateLoanCommand command)
        {
            var loanType = loanTypeRepository.Get(command.LoanTypeId);
            var loan = Loan.CreateLoan(command.OwnerId, loanType, command.LoanAmount);
            loanRepository.Save(loan);
        }
    }
}

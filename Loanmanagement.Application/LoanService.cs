using Loanmanagement.Application.Contract;
using LoanManagement.Domain.LoanAggregate;
using LoanManagement.Domain.LoanTypeAggregate;
using System;

namespace Loanmanagement.Application
{
    public class LoanService
    {
        private readonly ILoanRepository loanRepository;
        private readonly ILoanTypeRepository loanTypeRepository;

        public LoanService(ILoanRepository loanRepository, ILoanTypeRepository loanTypeRepository)
        {
            this.loanRepository = loanRepository;
            this.loanTypeRepository = loanTypeRepository;
        }

        public void CreateLoan(CreateLoanCommand createLoanCommand)
        {
            //log entry CreatLoan
            try
            {
                var loanType = loanTypeRepository.Get(createLoanCommand.LoanTypeId);
                var loan = Loan.CreateLoan(Guid.NewGuid(), loanType, createLoanCommand.LoanAmount);
                loanRepository.Save(loan);
                //log exit CreatLoan
            }
            catch (Exception ex)
            {
                //log exception
                throw;
            }

        }

        public void Approve(ApproveLoanCommand command)
        {
            try
            {
                var loan = loanRepository.Get(command.LoanId);
                loan.Approve();


                loanRepository.Update(loan);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Approve(PayLoanCommand command)
        {
            var loan = loanRepository.Get(command.LoanId);
            loan.Pay();


            loanRepository.Update(loan);
        }
    }
}

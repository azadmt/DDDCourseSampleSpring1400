using LoanManagement.Domain.LoanAggregate;
using LoanManagement.Domain.LoanTypeAggregate;
using System;
using System.Linq;

namespace LoanManagement.Persistence.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanManagementDbContext loanManagementManagementDbContext;

        public LoanRepository(LoanManagementDbContext loanManagementManagementDbContext)
        {
            this.loanManagementManagementDbContext = loanManagementManagementDbContext;
        }
        public Loan Get(Guid id)
        {
            return loanManagementManagementDbContext.Loans.SingleOrDefault(p=> p.Id==id);
        }

        public void Save(Loan loan)
        {
            loanManagementManagementDbContext.Loans.Add(loan);
            loanManagementManagementDbContext.SaveChanges();

        }

        public void Update(Loan loan)
        {
            loanManagementManagementDbContext.Loans.Update(loan);
            loanManagementManagementDbContext.SaveChanges();

        }
    }

    public class LoanTypeRepository : ILoanTypeRepository
    {
        private readonly LoanManagementDbContext loanManagementManagementDbContext;
        public LoanTypeRepository(LoanManagementDbContext loanManagementManagementDbContext)
        {
            this.loanManagementManagementDbContext = loanManagementManagementDbContext;
        }

        public LoanType Get(Guid id)
        {
            return loanManagementManagementDbContext.LoanTypes.SingleOrDefault(p => p.Id == id);
        }

        public void Save(LoanType entity)
        {
            loanManagementManagementDbContext.LoanTypes.Add(entity);
            loanManagementManagementDbContext.SaveChanges();
        }
    }
}

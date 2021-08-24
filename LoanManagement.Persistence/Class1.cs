using LoanManagement.Domain.LoanAggregate;
using System;

namespace LoanManagement.Persistence
{
    public class LoanRepository : ILoanRepository
    {
        //Ef,NHibernate,Dapper,ADO.NET
        public Loan Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Loan loan)
        {
            throw new NotImplementedException();
        }

        public void Update(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}

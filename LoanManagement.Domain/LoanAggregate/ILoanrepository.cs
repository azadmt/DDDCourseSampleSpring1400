using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Domain.LoanAggregate
{
    public interface ILoanRepository
    {
        Loan Get(Guid id);
        void Update(Loan loan);
        void Save(Loan loan);

    }

}

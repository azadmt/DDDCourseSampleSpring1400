using System;

namespace LoanManagement.Domain.LoanTypeAggregate
{
    public interface ILoanTypeRepository
    {
        void Save(LoanType entity);
        LoanType Get(Guid id);
    }

}
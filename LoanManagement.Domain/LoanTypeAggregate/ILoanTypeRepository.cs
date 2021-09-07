using Framework.Persistence.Ef;
using System;

namespace LoanManagement.Domain.LoanTypeAggregate
{
    public interface ILoanTypeRepository: IRepository
    {
        void Save(LoanType entity);
        LoanType Get(Guid id);
    }

}
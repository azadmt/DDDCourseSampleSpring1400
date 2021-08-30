
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Persistence
{
    public interface IUnitOfWork
    {
        IDbTransaction BeginTransaction();
        void Commit();
        void Rollback();

        Task<IDbTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
    

}

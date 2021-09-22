
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Persistence
{
    public interface IUnitOfWork
    {

        void Commit();
        void Rollback();

        Task CommitAsync();
        Task RollbackAsync();
    }
    

}

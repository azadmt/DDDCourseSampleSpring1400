using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Framework.Persistence.Ef
{
    public abstract class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction = Database.BeginTransaction();
            return (transaction as IInfrastructure<IDbTransaction>).Instance;
        }

        public Task<IDbTransaction> BeginTransactionAsync()
        {
            var transaction = Database.BeginTransactionAsync();
            return Task.Run(()=> (transaction.Result as IInfrastructure<IDbTransaction>).Instance);
        }

        public void Commit()
        {
            SaveChanges();
        }

        public Task CommitAsync()
        {
            return SaveChangesAsync();
        }

        public void Rollback()
        {

        }

        public Task RollbackAsync()
        {
            return Task.CompletedTask;
        }
    }
}

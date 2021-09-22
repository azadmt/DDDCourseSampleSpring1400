using Framework.Core.Messageing;
using Framework.Core.Persistence;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace Framework.Persistence.Ef
{
    public abstract class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<OutboxMessage> Outbox { get; set; }



        public void Commit()
        {
            PersistUnCommitdChanges();
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

        private void PersistUnCommitdChanges()
        {
            var listOfChanges = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged && x.Entity is AggregateRoot)
                .Select(x => x.Entity)
                .OfType<AggregateRoot>()
                .ToList();
            var uncommitedEvents = listOfChanges.SelectMany(p => p.GetUnCommitedChanges());
            var outboxList = uncommitedEvents.Select(p => new OutboxMessage { Id = Guid.NewGuid(), MessageType = p.GetType().ToString(), MessageContent = JsonConvert.SerializeObject(p) });
            Outbox.AddRange(outboxList);
        }
    }
}

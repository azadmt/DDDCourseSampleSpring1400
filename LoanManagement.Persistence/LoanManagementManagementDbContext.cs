using Framework.Persistence.Ef;
using LoanManagement.Domain.LoanAggregate;
using LoanManagement.Domain.LoanTypeAggregate;
using LoanManagement.Persistence.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace LoanManagement.Persistence
{

    public class LoanManagementDbContext : ApplicationDbContext
    {

        public LoanManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanType>().HasData(
                 new LoanType(Guid.Parse("1EEB33ED-519E-4DD4-9634-5E0383172230"),"A",11,250)
                 
 );
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}

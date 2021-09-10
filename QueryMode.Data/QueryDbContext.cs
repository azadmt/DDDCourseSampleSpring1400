using Microsoft.EntityFrameworkCore;
using QueryModel.Data.DataModel;
using System;

namespace QueryModel.Data
{
    public class QueryDbContext : DbContext
    {
        public QueryDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<LoanView> Loans { get; set; }
        public DbSet<LoanTypeView> LoanTypes { get; set; }
        public DbSet<CustomerView> CustomerViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

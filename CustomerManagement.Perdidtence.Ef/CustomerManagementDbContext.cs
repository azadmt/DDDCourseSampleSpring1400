using CustomerManagement.Domain.Customer;
using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CustomerManagement.Persistence.Ef
{
    public class CustomerManagementDbContext : ApplicationDbContext
    {
        public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<CustomerAggregate> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(CustomerManagementDbContext)));
            base.OnModelCreating(modelBuilder);
        }
    }
}

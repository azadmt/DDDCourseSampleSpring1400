using CustomerManagement.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Perdidtence.Ef
{
    public class CustomerManagementDbContext : DbContext
    {
        public DbSet<CustomerAggregate> Customers { get; set; }
    }
}

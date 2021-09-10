using CustomerManagement.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerManagement.Persistence.Ef
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerManagementDbContext dbContext;

        public CustomerRepository(CustomerManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(CustomerAggregate customerAggregate)
        {
            dbContext.Add(customerAggregate);
        }

        public CustomerAggregate Get(Guid id)
        {
            return dbContext.Customers.FirstOrDefault(p => p.Id == id);
        }
    }
}

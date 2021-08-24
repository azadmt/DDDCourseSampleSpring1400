using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Domain.Customer
{
    public interface ICustomerRepository
    {
        void Add(CustomerAggregate customerAggregate);
        CustomerAggregate Get(Guid id);
    }
}

using CustomerManagement.ApplicationService.Contract.ServiceContract;
using CustomerManagement.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.ApplicationService.Customer
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void CreateCustomer(string nationalCode)
        {
            var customer = new CustomerAggregate(Guid.NewGuid(), nationalCode);
            customerRepository.Add(customer);
        }


        public void Approve(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }

}

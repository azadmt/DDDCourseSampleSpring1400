using CustomerManagement.ApplicationService.Contract.DataContract;
using CustomerManagement.Domain.Customer;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.ApplicationService.Customer
{
    public class ApproveCustomerCommandHandler :  
        ICommandHandler<ApproveCustomerCommand>
    {
        ICustomerRepository _customerRepository;
        public ApproveCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Handle(ApproveCustomerCommand command)
        {
            throw new Exception();
            //var customer=_customerRepository.Get(command.Id);
            //customer.Approve();
        }
    }
}

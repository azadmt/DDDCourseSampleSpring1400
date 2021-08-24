using CustomerManagement.ApplicationService.Contract.DataContract;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.ApplicationService.Customer
{
    public class CreateCustomerCommandHandler : 
        ICommandHandler<CreateCustomerCommand>
    {
        public void Handle(CreateCustomerCommand command)
        {
          
        }
    }
}

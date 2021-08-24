using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.ApplicationService.Contract.ServiceContract
{
    public interface ICustomerService
    {
         void CreateCustomer(string nationalCode);
         void Approve(Guid customerId);
    }
}

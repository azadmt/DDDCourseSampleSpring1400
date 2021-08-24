using CustomerManagement.ApplicationService.Contract.ServiceContract;

using System;

namespace CustomerManagement.COnsole
{
    class Program
    {
      static ICustomerService customerService;
        static void Main(string[] args)
        {
            customerService.CreateCustomer("2542542354");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.ApplicationService.Contract.ServiceContract;

using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        // commandbus
        readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService )
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult CreateCustomer(string nationalCode)
        {
            _customerService.CreateCustomer(nationalCode);
            return View();
        }

        [HttpPost]
        public IActionResult Approve(Guid customerId)
        {
            _customerService.Approve(customerId);
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.ApplicationService.Contract.DataContract;
using CustomerManagement.ApplicationService.Contract.ServiceContract;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        // commandbus
        readonly ICustomerService _customerService;
        private readonly ICommandBus commandBus;

        public CustomerController(ICommandBus commandBus)
        {
 
            this.commandBus = commandBus;
        }

        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerCommand command)
        {
            commandBus.Send(command);
            return Ok();
        }


        [HttpPost("Approve")]
        public IActionResult Approve(Guid customerId)
        {
            _customerService.Approve(customerId);
            return Ok();
        }
    }
}
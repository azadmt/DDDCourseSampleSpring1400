using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Application;
using Loanmanagement.Application;
using Loanmanagement.Application.Contract;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ICommandBus bus;

        public LoanController(ICommandBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public IActionResult Get()
        {
          
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateLoan(CreateLoanCommand command)
        {
            bus.Send(command);
            return Ok();
        }
    }
}
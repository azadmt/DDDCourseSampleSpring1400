using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.ApplicationService.Contract.DataContract;
using CustomerManagement.ApplicationService.Contract.ServiceContract;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

  
        public WeatherForecastController(ICommandBus command)
        {
            CommandBus = command;
        }

        public ICommandBus CommandBus { get; }

        [HttpGet]
        public IActionResult Get()
        {
           // CommandBus.Send(new CreateCustomerCommand { NationalCode = "13123123" });
            CommandBus.Send(new ApproveCustomerCommand { });
            return Ok();
        }
    }
}

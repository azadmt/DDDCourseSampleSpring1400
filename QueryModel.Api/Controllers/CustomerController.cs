using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QueryModel.Data;
using QueryModel.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueryModel.Api.Controllers
{

    [ApiController]
    [Route("Query/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly QueryDbContext queryDbContext;

        public CustomerController(QueryDbContext queryDbContext)
        {
            this.queryDbContext = queryDbContext;
        }


        [HttpGet]
        public IEnumerable<CustomerView> Get()
        {
            return queryDbContext.CustomerViews.ToList();
        }
    }
}

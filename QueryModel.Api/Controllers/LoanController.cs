using Microsoft.AspNetCore.Mvc;
using QueryModel.Data;
using QueryModel.Data.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace QueryModel.Api.Controllers
{
    [ApiController]
    [Route("Query/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly QueryDbContext queryDbContext;

        public LoanController(QueryDbContext queryDbContext)
        {
            this.queryDbContext = queryDbContext;
        }


        [HttpGet]
        public IEnumerable<LoanView> Get()
        {
            return queryDbContext.Loans.ToList();
        }
    }
}

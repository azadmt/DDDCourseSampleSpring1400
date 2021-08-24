using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loanmanagement.Application;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Api.Controllers
{
    public class LoanController : Controller
    {
        private LoanService loanService;
        public LoanController(LoanService loanService)
        {
        
        }
        
        [HttpPost]
        public IActionResult CreateLoan(CreateLoanCommand command)
        {
            loanService.CreateLoan(command);
            return Ok();
        }
    }
}
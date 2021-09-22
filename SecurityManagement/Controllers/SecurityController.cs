using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SecurityManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        [HttpPost]
        public IActionResult Login(Model.LoginModel loginModel)
        {
            string token = string.Empty;
            //authenticate 

            if (InMemoryDB.Users.Any(p => p.Username == loginModel.Username && p.Password == loginModel.Password))
            {
                token = Guid.NewGuid().ToString();
                InMemoryDB.Claims.Add
                    (token,
                    new UserClaim()
                    {
                        Permission = InMemoryDB.UserPermissions[loginModel.Username],
                        Username = loginModel.Username

                    });
            }
            return Ok(new { Token = token });
        }

        [HttpGet]
        public UserClaim Get(string token)
        {
            var permission = InMemoryDB.Claims[token];
            return permission;
        }
    }
}

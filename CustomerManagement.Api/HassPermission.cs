using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;

namespace CustomerManagement.Api
{
    public class HassPermission : ActionFilterAttribute
    {
        public string Operation { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpClient httpClient = new HttpClient();
            var token = context.HttpContext.Request.Headers["token"];
            var result = httpClient.GetAsync("http://localhost:17402/api/Security?token=" + token).Result.Content.ReadAsStringAsync().Result;
            var userClaim = JsonConvert.DeserializeObject<UserClaim>(result);

            if (!userClaim.Permission.Contains(Operation))
            {
                //get user claim from security service
                //check user.Operation.contains(Operetion)
                context.Result = new UnauthorizedObjectResult("user is unauthorized");
            }
            base.OnActionExecuting(context);
        }
    }

    public class UserClaim
    {
        public string Username { get; set; }
        public string[] Permission { get; set; }
    }
}

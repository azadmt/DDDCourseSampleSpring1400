using Microsoft.AspNetCore.Mvc.Filters;

namespace QueryModel.Api
{
    public class HassPermission: ActionFilterAttribute
    {
        public string Operation { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}

using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using AssessmentDemo.Foundation.Model;

namespace NetFrameworkWebAPI.Filters
{
    public class PriceFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            foreach (var argument in actionContext.ActionArguments.Values.Where(v => v is Gift))
            {
                var model = argument as Gift;
                if (model.Price > 100)
                {
                    Console.WriteLine("Gift price is quite high");
                }
            }
        }
    }
}
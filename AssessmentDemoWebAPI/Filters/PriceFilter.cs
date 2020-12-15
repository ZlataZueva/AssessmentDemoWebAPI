using System.Linq;
using System.Threading.Tasks;
using AssessmentDemo.Foundation.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AssessmentDemoWebAPI.Filters
{
    public class PriceFilter : IAsyncActionFilter
    {
        private readonly ILogger<PriceFilter> _logger;


        public PriceFilter(ILogger<PriceFilter> logger)
        {
            _logger = logger;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var argument in context.ActionArguments.Values.Where(v => v is Gift))
            {
                var model = argument as Gift;
                if (model.Price > 100)
                {
                    _logger.LogWarning("Gift price is quite high");
                }
            }

            await next.Invoke();
        }
    }
}
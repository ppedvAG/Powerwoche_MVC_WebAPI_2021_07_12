using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Filters
{
    public class ActionFilterExample : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes
        }
    }


    public class ActionFilterAsyncExample : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // execute any code before the action executes
            var result = await next(); //Call next Filter
            // execute any code after the action executes
        }
    }
}

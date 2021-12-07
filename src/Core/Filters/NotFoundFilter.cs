using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.Filters;

public class NotFoundFilter : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context is { Result: ObjectResult result } && result is { Value: null })
        {
            context.Result = new NotFoundResult();
        }
        else
        {
            base.OnActionExecuted(context);
        }
    }
}

using Core.Contexts;
using Infra.Contexts;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infra.Filters;

public class TransactionFilter : IAsyncActionFilter
{
    private readonly Context _DbContext;
    private readonly INotificationContext _notificationContext;

    public TransactionFilter(Context dbContext, INotificationContext notificationContext)
    {
        _DbContext = dbContext;
        _notificationContext = notificationContext;
    }

    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        var result = await next();
        if (_notificationContext.IsEmpty || result.Exception == null || result.ExceptionHandled)
            await _DbContext.SaveChangesAsync();
    }
}
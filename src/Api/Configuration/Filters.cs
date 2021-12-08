using Core.Filters;
using Infra.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Api.Configuration;

public static class Filters
{
    public static void AddFilters(MvcOptions options)
    {
        options.Filters.Add(typeof(CustomNotificationFilter));
        options.Filters.Add(typeof(TransactionFilter));
        options.Filters.Add(typeof(NotFoundFilter));
        options.Filters.Add(typeof(NoContentFilter));
        options.Filters.Add(typeof(ExceptionFilter));
    }
}
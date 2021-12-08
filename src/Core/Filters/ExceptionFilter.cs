using Core.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Filters;

public class ExceptionFilter : IExceptionFilter
{
    private static readonly Notification DefaultError = new("Internal Server Error",
        "Ocorreu um erro inesperado, entre em contato com o administrador");

    private readonly IHostingEnvironment _env;

    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(IHostingEnvironment env, ILogger<ExceptionFilter> logger)
    {
        _env = env;
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        if (!_env.IsProduction()) return;

        var result = new ObjectResult(DefaultError);
        result.StatusCode = 500;

        context.Result = result;
    }
}
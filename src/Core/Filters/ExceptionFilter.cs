using Core.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
namespace Core.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {

        private readonly IHostingEnvironment _env;

        private readonly ILogger<ExceptionFilter> _logger;

        private static readonly Notification DefaultError = new Notification("Internal Server Error", "Ocorreu um erro inesperado, entre em contato com o administrador");

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
}
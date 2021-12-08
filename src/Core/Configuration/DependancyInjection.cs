using Core.Contexts;
using Core.Filters;
using Core.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration;

public static class DependancyInjection
{
    public static void AddContexts(this IServiceCollection services)
    {
        services.AddScoped<INotificationContext, NotificationContext>();
        services.AddScoped<CustomNotificationFilter>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
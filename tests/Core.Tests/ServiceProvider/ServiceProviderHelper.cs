using Core.Tests.Contexts;
using Infra.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Core.Tests.ServiceProvider;
public static class ServiceProviderHelper
{
    public static IServiceCollection Mock<T>(this IServiceCollection services, T mock, ServiceLifetime lifetime = ServiceLifetime.Transient) where T : class
    {
        var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(T));

        if (descriptor is not null)
            services.Remove(descriptor);

        services.Add(new ServiceDescriptor(typeof(T), p => mock, descriptor?.Lifetime ?? lifetime));

        return services;
    }

    public static IServiceCollection MockDbContext<T, TTarget>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient) where T : DbContext where TTarget : T
    {
        var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(T));

        if (descriptor is not null)
            services.Remove(descriptor);

        services.AddDbContext<Context, TestContext>(opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));

        return services;
    }

    public static IServiceCollection Mock<T, TTarget>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient) where T : class where TTarget : T
    {
        var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(T));

        if (descriptor is not null)
            services.Remove(descriptor);

        services.Add(new ServiceDescriptor(typeof(T), typeof(TTarget), descriptor?.Lifetime ?? lifetime));

        return services;
    }
}

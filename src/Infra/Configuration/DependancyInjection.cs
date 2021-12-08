using System.Reflection;
using Domain.Entities.Pros;
using Domain.Repositories;
using Infra.Contexts;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Configuration;

public static class DependancyInjection
{
    public static void AddRepositories(this IServiceCollection services, Assembly[] assemblies,
        IConfiguration configuration)
    {
        services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("Main")));
        services.AddTransient<IReferralCodeRepository, ReferralCodeRepository>();
        services.AddGenericRepositories(assemblies);
    }

    private static IEnumerable<Type> GetTypesOfImplementations(Assembly[] assemblies, Type it, Type baseType)
    {
        return assemblies.SelectMany(a => a.DefinedTypes.Where(x =>
            !x.IsAbstract
            && !x.IsInterface
            && x.BaseType is not null
            && x.BaseType.IsGenericType
            && x.BaseType.GetGenericTypeDefinition() == baseType
            && x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == it))
        ).ToList();
    }

    private static void AddGenericRepositories(this IServiceCollection services, Assembly[] assemblies)
    {
        var it = typeof(IRepository<>);
        var baseType = typeof(Repository<>);
        var types = GetTypesOfImplementations(assemblies, it, baseType);
        foreach (var type in types)
        {
            var nonGenericType = it.MakeGenericType(type.BaseType.GetGenericArguments());
            var typeMostSpecificInterface = type.GetInterfaces().First(x => x != nonGenericType);
            services.Add(new ServiceDescriptor(typeMostSpecificInterface, type, ServiceLifetime.Scoped));
        }
    }
}
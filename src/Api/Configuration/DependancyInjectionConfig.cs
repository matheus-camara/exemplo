using System.Reflection;
using Core.Configuration;
using Domain.Configuration;
using Infra.Configuration;
using MediatR;

namespace Api.Configuration;

public static class DependancyInjectionConfig
{
    private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();

    private static Assembly[] GetAssemblies()
    {
        var assemblies = _assembly.GetReferencedAssemblies().Select(x => Assembly.Load(x));
        assemblies = assemblies.Append(_assembly);
        return assemblies.ToArray();
    }

    public static void AddDependancyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        var assemblies = GetAssemblies();
        services.AddRepositories(assemblies, configuration);
        services.AddMediatR(assemblies);
        services.AddMappers();
        services.AddValidators(assemblies);
        services.AddContexts();
    }
}
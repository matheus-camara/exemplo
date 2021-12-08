﻿using System.Reflection;
using Domain.Configuration.MappingProfile;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Configuration;

public static class DependancyInjection
{
    public static void AddValidators(this IServiceCollection services, Assembly[] assemblies)
    {
        AssemblyScanner.FindValidatorsInAssemblies(assemblies)
            .ForEach(x => { services.AddScoped(x.InterfaceType, x.ValidatorType); });
    }

    public static void AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainToCommandMappingProfile), typeof(CommandToDomainMappingProfile),
            typeof(GlobalProfile));
    }
}
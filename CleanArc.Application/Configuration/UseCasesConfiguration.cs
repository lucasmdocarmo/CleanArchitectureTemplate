using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using CleanArc.Application.Contracts.UseCases.Interactors;
using static System.Reflection.Assembly;

[assembly: InternalsVisibleTo("CleanArc.API")]
namespace CleanArc.Application.Shared.Configuration
{
    internal static class UseCasesConfiguration
    {
        public static IServiceCollection AddRegisterUseCases(this IServiceCollection services)
        {
            GetExecutingAssembly().GetTypes().
            Where(item => item.GetInterfaces().
            Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IUseCase<>)) && !item.IsAbstract && !item.IsInterface).
            ToList().
            ForEach(assignedTypes =>
            {
                var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IUseCase<>));
                services.AddScoped(serviceType, assignedTypes);

            });

            return services;
        }
    }
}

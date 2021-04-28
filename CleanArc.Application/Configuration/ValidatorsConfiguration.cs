using Flunt.Validations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CleanArc.API")]
namespace CleanArc.Application.Shared.Configuration
{
    internal static class ValidatorsConfiguration
    {
        public static IServiceCollection AddRegisterValidators(this IServiceCollection services)
        {
            services.AddScoped(typeof(Contract<>), typeof(Contract<>));
            return services;
        }
    }
}

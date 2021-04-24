using CleanArc.Application.UseCases.CreateClient.Presenter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CleanArc.API")]
namespace CleanArc.Application.Profiles
{
    internal static class AutoMapperConfiguration
    {
        public static IServiceCollection AddRegisteredMappers(this IServiceCollection services)
        {
           services.AddAutoMapper(typeof(CreateClientProfiler));

            return services;
        }
    }
}

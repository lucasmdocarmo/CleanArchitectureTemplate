using CleanArc.Application.Contracts.Ports;
using CleanArc.Application.Shared.Presentation;
using CleanArc.Application.UseCases.CreateClient.Ports;
using CleanArc.Application.UseCases.CreateClient.Presenter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArc.API.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBasePresenter, BasePresenter>();

            services.AddScoped<ICreateClientPort, CreateClientPresenter>();
            services.AddScoped<CreateClientPresenter>();

            return services;
        }
    }
}

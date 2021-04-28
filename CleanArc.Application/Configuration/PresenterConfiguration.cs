using CleanArc.Application.Contracts.Ports;
using CleanArc.Application.Shared.Presentation;
using CleanArc.Application.UseCases.CreateClient.Ports;
using CleanArc.Application.UseCases.CreateClient.Presenter;
using CleanArc.Application.UseCases.DeleteClient.Ports;
using CleanArc.Application.UseCases.DeleteClient.Presenter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CleanArc.API")]
namespace CleanArc.Application.Configuration
{
    internal static class PresenterConfiguration
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBasePresenter, BasePresenter>();

            services.AddScoped<ICreateClientPort, CreateClientPresenter>();
            services.AddScoped<CreateClientPresenter>();

            services.AddScoped<IDeleteClientPort, DeleteClientPresenter>();
            services.AddScoped<DeleteClientPresenter>();

            return services;
        }
    }
}

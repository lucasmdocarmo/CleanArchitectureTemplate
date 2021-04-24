using CleanArc.Domain.Shared.Contracts;
using CleanArc.Domain.Shared.Contracts.UnitOfWork;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Contracts;
using CleanArch.Infrastructure.Repositories;
using CleanArch.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CleanArc.API")]
namespace CleanArch.Infrastructure.Configuration
{
    internal static class RepositoriesConfiguration
    {
        internal static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<APIContext>(db => db.UseSqlServer(configuration.GetConnectionString("AppConnString")));
            services.AddScoped<APIContext>();
            services.AddScoped<IUnitOfWork, APIContext>();
            services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }
    }
}

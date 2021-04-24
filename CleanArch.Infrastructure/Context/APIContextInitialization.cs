using CleanArc.Domain.Shared.Contracts.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CleanArc.API")]
namespace CleanArch.Infrastructure.Context
{
    internal static class APIContextInitialization
    {
        public static void EnsureMigrationOfContext(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetService<APIContext>();
            {
                context.Database.EnsureCreated();
            }
        }
    }
}

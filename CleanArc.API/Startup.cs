using CleanArc.API.Configuration;
using CleanArc.Application.Configuration;
using CleanArc.Application.Profiles;
using CleanArc.Application.Shared.Configuration;
using CleanArch.Infrastructure.Configuration;
using CleanArch.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArc.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersConfiguration();
            services.AddCustomVersioning();
            services.AddRegisterServices();
            services.AddRegisterUseCases();
            services.AddRegisterValidators();
            services.AddRepositories(Configuration);
            services.AddAutoMapper(typeof(Startup));
            services.AddRegisteredMappers();
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

            app.UsePathBase("/clean-archi-api");
            app.EnsureMigrationOfContext();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArc.API v1"));
            app.UseRequestLocalization();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseHsts();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

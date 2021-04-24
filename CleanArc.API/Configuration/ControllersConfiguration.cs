using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleanArc.API.Configuration
{
    public static class ControllersConfiguration
    {
        public static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            }).AddControllersAsServices();

            services.AddHttpContextAccessor().AddMvc(options =>
            {
                options.OutputFormatters.RemoveType<TextOutputFormatter>();
                options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                options.RespectBrowserAcceptHeader = true;
            });

            return services;
        }
    }
}

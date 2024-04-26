using Flyhigh.Backend.Repos;
using Flyhigh.HttpService.Service;
using Flyhigh.Shared.Assamblers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Flyhigh.Desktop.Extensions
{
    public static class FlyhighBackendExtensions
    {
        public static void ConfigureHttpCliens(this IServiceCollection services)
        {
            services.AddHttpClient("FlyhighApi", options =>
            {
                options.BaseAddress = new Uri("https://localhost:7090/");
            });
        }

        public static void ConfigureApiServices(this IServiceCollection services)
        {
            services.AddScoped<IGepService, GepService>();
            services.AddScoped<IGepAdatokTipusService, GepAdatokTipusService>();
            services.AddScoped<IReptarsService, ReptarsService>();
            services.AddScoped<IJogosultsagokService, JogosultsagokService>();
            services.AddScoped<IJegyService, JegyService>();
            services.AddScoped<IJegyTipusService, JegyTipusService>();


        }

        public static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<GepAdatokAssambler>();
            services.AddScoped<GepAdatokTipusAssambler>();
            services.AddScoped<FelhasznaloAssambler>();
            services.AddScoped<RepuloAssambler>();
            services.AddScoped<JegyAssambler>();
            services.AddScoped<JegyTipusAssambler>();


        }
    }
}

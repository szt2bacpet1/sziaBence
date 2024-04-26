using Flyhigh.Backend.Context;
using Flyhigh.Shared.Assamblers;
using Flyhigh.Backend.Repos;
using Flyhigh.Backend.Repos.
using Flyhigh.Backend.Repos.SwitchTables;
using Flyhigh.Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Flyhigh.Backend.Extensions
{
    public static class FlyhighBackendExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(option =>
                 option.AddPolicy(name: "FlyhighCors",
                     policy =>
                     {
                         policy.WithOrigins("https://localhost:7090/")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     }
                 )
            );
        }

        public static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbName = "Flyhigh" + Guid.NewGuid();
            //services.AddDbContextFactory<FlyhighContext>(
            //    options => options.UseInMemoryDatabase(databaseName: dbName)
            //    );
            services.AddDbContextFactory<FlyhighInMemoryContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
                );
            string connectionString = "server=localhost;userid=root;password=;database=kreta;port=3306";
            services.AddDbContext<FlyhighMySqlContext>(options => options.UseMySQL(connectionString));
        }
        


        public static void ConfigureRepoService(this IServiceCollection services)
        {
            bool test = false;
            if (test)
            {
                services.AddScoped<IGepRepo, GepAdatokInMemoryRepo<FlyhighInMemoryContext>>();
                services.AddScoped<IGepAdatokTipusRepo, GepAdatokTipusInMemoryRepo<FlyhighInMemoryContext>>();
                services.AddScoped<IRepulotarsRepo, RepuloInMemoryRepo<FlyhighInMemoryContext>>();
                services.AddScoped<IFelhasznaloRepo, FelhasznaloInMemoryRepo<FlyhighInMemoryContext>>();
                services.AddScoped<ICountriesRepo, CountryInMemoryRepo<FlyhighInMemoryContext>>();
                services.AddScoped<IJogosultsagiSzintsRepo, JogosultsagiSzintInMemoryRepo<FlyhighInMemoryContext>>();
                services.AddScoped<IJegyRepo, JegyInMemoryRepo<FlyhighInMemoryContext>>();
                services.AddScoped<IJegyTipusRepo, JegyTipusInMemoryRepo<FlyhighInMemoryContext>>();
            }
            else
            {
                services.AddScoped<IGepRepo, GepAdatokInMemoryRepo<FlyhighMySqlContext>>();
                services.AddScoped<IGepAdatokTipusRepo, GepAdatokTipusInMemoryRepo<FlyhighMySqlContext>>();
                services.AddScoped<IRepulotarsRepo, RepuloInMemoryRepo<FlyhighMySqlContext>>();
                services.AddScoped<IFelhasznaloRepo, FelhasznaloInMemoryRepo<FlyhighMySqlContext>>();
                services.AddScoped<ICountriesRepo, CountryInMemoryRepo<FlyhighMySqlContext>>();
                services.AddScoped<IJogosultsagiSzintsRepo, JogosultsagiSzintInMemoryRepo<FlyhighMySqlContext>>();
                services.AddScoped<IJegyRepo, JegyInMemoryRepo<FlyhighMySqlContext>>();
                services.AddScoped<IJegyTipusRepo, JegyTipusInMemoryRepo<FlyhighMySqlContext>>();
            }

        }

        public static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<GepAdatokAssambler>();
            services.AddScoped<GepAdatokTipusAssambler>();
            services.AddScoped<FelhasznaloAssambler>();
            services.AddScoped<RepuloAssambler>();
            services.AddScoped<CountriesAssambler>();
            services.AddScoped<JogosultsagiSzintAssambler>();
            services.AddScoped<JegyAssambler>();
            services.AddScoped<JegyTipusAssambler>();

        }
    }
}
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperStoreAPI.SQL;
using SuperStoreAPI.SQL.Context;
using SuperStoreAPI.SQL.Context.Interfaces;
using SuperStoreAPI.SQL.Repositories.Interfaces;

[assembly: FunctionsStartup(typeof(SuperStoreAPI.Startup))]
namespace SuperStoreAPI
{
    public class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfigurationRoot localConfig = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddLogging();

            AddScopedRepositories(builder);


            builder.Services.AddDbContext<ISuperStoreContext, SuperStoreContext>(
               options =>
                {
                    options.UseSqlServer(
                        localConfig.GetConnectionString("SUPER_STORE_CONNECTION"),
                        sqlServerOptions => sqlServerOptions.CommandTimeout(120));

                    if (localConfig.GetSection("ENVIRONMENT").Value == "local")
                    {
                        options.EnableSensitiveDataLogging();
                    }
                }
            );
        }

        private static void AddScopedRepositories(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
        }
    }
}

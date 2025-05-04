using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using Shared.Data;

namespace Catalog;
public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        
        //api endpoint services
        // application use case services
        // infrastructure services
     
        var connectionString = DatabaseConfig.GetConnectionString(configuration);

            // Register the DbContext with Npgsql
            services.AddDbContext<CatalogDbContext>(options =>
                options.UseNpgsql(connectionString));
                
        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app){
        
        //api endpoint services
        // application use case services
        // infrastructure services
        app.UseMigration<CatalogDbContext>();

        return app;
    }

}




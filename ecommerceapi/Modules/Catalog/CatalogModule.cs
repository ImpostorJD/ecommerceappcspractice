using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Catalog;
public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        
        // services.AddApplicationServices()
        //     .AddInfrastructureServices(configuration)
        //     .AddApiServices(configuration);

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app){
        
        // app.UseApplicationServices()
        //     .UseInfrastructureServices()
        //     .UseApiServices();

        
        return app;
    }
}




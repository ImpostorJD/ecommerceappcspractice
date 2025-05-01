using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Basket;

public static class BasketModule
{
 public static IServiceCollection AddBasketModule(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddApplicationServices()
        //     .AddInfrastructureServices(configuration)
        //     .AddApiServices(configuration);

        return services;
    }
    public static IApplicationBuilder UseBasketModule(this IApplicationBuilder app){
        
        // app.UseApplicationServices()
        //     .UseInfrastructureServices()
        //     .UseApiServices();
        
        return app;
    }
}

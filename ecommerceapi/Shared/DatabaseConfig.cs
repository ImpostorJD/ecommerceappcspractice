using DotNetEnv;
using Microsoft.Extensions.Configuration;

namespace Shared;

public static class DatabaseConfig

{
    
     public static string GetConnectionString(IConfiguration configuration)
    {
        Env.Load();

        // var dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
        // var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
        // var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "ECommerceShop";
        // var dbUsername = Environment.GetEnvironmentVariable("DB_UNAME") ?? "postgres";
        // var dbPassword = Environment.GetEnvironmentVariable("DB_PASS") ?? "";
        var dbServer = configuration["DB_SERVER"] ?? "localhost";
        var dbPort = configuration["DB_PORT"] ?? "5432";
        var dbName = configuration["DB_NAME"] ?? "ECommerceShop";
        var dbUsername = configuration["DB_UNAME"] ?? "postgres";
        var dbPassword = configuration["DB_PASS"] ?? "";

        return $"Host={dbServer};Port={dbPort};Database={dbName};Username={dbUsername};Password={dbPassword}";
    }
}
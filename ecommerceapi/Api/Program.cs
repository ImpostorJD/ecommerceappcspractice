using DotNetEnv;
using Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

builder.Configuration.AddEnvironmentVariables();

builder.Services
    .AddOpenApi()
    .AddCors(options =>{
        options.AddPolicy("AllowLocalhost", policy =>
            policy.WithOrigins("http://localhost:5173") 
                .AllowAnyHeader()
                .AllowAnyMethod());
    })
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration)
    .AddControllers()
    .AddApplicationPart(typeof (Catalog.Controllers.CatalogController).Assembly);

var app = builder.Build();

app.UseMiddleware<ExceptionsHandler>();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
else
{
    app.UseHsts();
}


app.UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();

app.UseCors("AllowLocalhost")
    .UseStaticFiles()
    .UseHttpsRedirection()
    .UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}"); 

var clientAppPath = Path.GetFullPath(
    Path.Combine(
        AppContext.BaseDirectory, 
        "..", "..", "..",       
        "..",                  
        "client-app"            
    )
);


// var reactProcess = new ProcessStartInfo("npm", "run client")
// {

//     WorkingDirectory = clientAppPath, 
//     UseShellExecute = true,
//     CreateNoWindow = false
// };
// Process.Start(reactProcess);

app.Run(); 

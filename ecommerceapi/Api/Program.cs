using System.Diagnostics;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

builder.Services.AddControllers();
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
    .AddOrderingModule(builder.Configuration);

var app = builder.Build();

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
    
app.MapControllers();

var clientAppPath = Path.GetFullPath(
    Path.Combine(
        AppContext.BaseDirectory, 
        "..", "..", "..",       
        "..",                  
        "client-app"            
    )
);

Console.WriteLine(clientAppPath);

var reactProcess = new ProcessStartInfo("npm", "run client")
{

    WorkingDirectory = clientAppPath, 
    UseShellExecute = true,
    CreateNoWindow = false
};
Process.Start(reactProcess);

app.Run(); 

using EntityFramework;
using Store.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;
var configuration = builder.Configuration;
var environment = builder.Environment;

var healthChecks = services.AddHealthChecks();
services.ConfigureServices(configuration);

var app = builder.Build();
using var scope = app.Services.CreateScope();
DataDependencies.InitializeDatabaseAsync(scope).GetAwaiter().GetResult();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

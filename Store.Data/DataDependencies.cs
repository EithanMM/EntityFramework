using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Data.Repositories;
using Store.Data.Services;

namespace Store.Data;

public static class DataDependencies
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        // services Wiring
        services.AddTransient<IStoreService, StoreService>();

        services.AddDbContext<TestDatabaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("EntityFrameworkDB")));

        services.AddTransient<ITestDatabaseRepository, TestDatabaseRepository>();
        services.AddScoped<TestDatabaseDbContextInitializer>();
    }

    public static async Task InitializeDatabaseAsync(IServiceScope scope)
    {
        var databaseInitializer = scope.ServiceProvider.GetService<TestDatabaseDbContextInitializer>();

        if(databaseInitializer is not null)
            await databaseInitializer.InitializeAsync();
    }
}

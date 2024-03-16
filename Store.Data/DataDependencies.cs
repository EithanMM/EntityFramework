using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Data;

public static class DataDependencies
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        // services Wiring

        services.AddDbContext<TestDatabaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("EntityFrameworkDB")));

        services.AddScoped<TestDatabaseDbContextInitializer>();
    }

    public static async Task InitializeDatabaseAsync(IServiceScope scope)
    {
        var databaseInitializer = scope.ServiceProvider.GetService<TestDatabaseDbContextInitializer>();

        if(databaseInitializer is not null)
            await databaseInitializer.InitializeAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Store.Data;

public sealed class TestDatabaseDbContextInitializer(TestDatabaseDbContext context, ILogger<TestDatabaseDbContext> logger)
{
    public async Task InitializeAsync()
    {
		try
		{
			if (context.Database.IsSqlServer())
				await context.Database.MigrateAsync();
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "An error ocurrer while initializing the database");
			throw;
		}
    }
}

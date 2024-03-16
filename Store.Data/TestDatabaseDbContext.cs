using Microsoft.EntityFrameworkCore;
using Store.Data.Entities.Store;
using System.Reflection;

namespace Store.Data;

public class TestDatabaseDbContext(DbContextOptions<TestDatabaseDbContext> options) : DbContext(options)
{
    public DbSet<StoreEntity> Stores => Set<StoreEntity>();


    // Could add interceptors (exampl, classes that inherit from SaveChangesInterceptor)
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    // Could pre-configure entities default values
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Allow to apply entities configuration withou specifing it here
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

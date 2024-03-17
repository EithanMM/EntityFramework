using Store.Data.Entities.Store;

namespace Store.Data.Repositories;

public class TestDatabaseRepository(TestDatabaseDbContext dbContext) : Repository<TestDatabaseDbContext>(dbContext), ITestDatabaseRepository
{
    public IQueryable<StoreEntity> Stores => DbContext.Stores;
}

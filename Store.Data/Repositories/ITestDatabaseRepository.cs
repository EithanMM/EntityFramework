using Store.Data.Entities.Store;

namespace Store.Data.Repositories;

public interface ITestDatabaseRepository : IRepository
{
    // This class will contain all the IQueryable items
    // to manipulate the db entities transformed into objects

    IQueryable<StoreEntity> Stores { get; }
}

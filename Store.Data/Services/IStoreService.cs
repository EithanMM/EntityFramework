using Store.Data.Entities.Store;

namespace Store.Data.Services;

public interface IStoreService
{
    Task<IEnumerable<StoreEntity>> GetStoresAsync();
}

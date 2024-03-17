using Store.Data.Entities.Store;
using Store.Data.Repositories;

namespace Store.Data.Services
{
    public class StoreService( ITestDatabaseRepository testDatabaseRepository) : IStoreService
    {
        private readonly ITestDatabaseRepository _testDatabaseRepository = testDatabaseRepository;
        public async Task<IEnumerable<StoreEntity>> GetStoresAsync()
        {
            throw new NotImplementedException();
        }
    }
}

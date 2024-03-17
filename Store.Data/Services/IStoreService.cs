using Store.Core.Common;
using Store.Core.Models;

namespace Store.Data.Services;

public interface IStoreService
{
    Task<ResponseResult<PaginatedList<StoreModel>>> GetStoresAsync(CancellationToken cancellationToken);
}

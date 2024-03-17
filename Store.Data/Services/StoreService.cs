using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Store.Core.Common;
using Store.Core.Models;
using Store.Data.Extensions;
using Store.Data.Repositories;

namespace Store.Data.Services;

public class StoreService(IMapper mapper, ITestDatabaseRepository testDatabaseRepository) : IStoreService
{
    private const int pageSize = 10;
    private const int pageNumber = 1;

    private readonly IMapper _mapper = mapper;
    private readonly ITestDatabaseRepository _testDatabaseRepository = testDatabaseRepository;
    public async Task<ResponseResult<PaginatedList<StoreModel>>> GetStoresAsync(CancellationToken cancellationToken)
    {
        var storesQuery = _testDatabaseRepository.Stores.AsNoTracking();

        var stores = await storesQuery
            .ProjectTo<StoreModel>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(pageNumber, pageSize, cancellationToken);

        return new(stores);
    }
}

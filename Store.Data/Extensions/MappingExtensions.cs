using Microsoft.EntityFrameworkCore;
using Store.Core.Common;
using Store.Data.Common;

namespace Store.Data.Extensions;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken) where TDestination : class
        => PaginatedListHelper.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize, cancellationToken);
}

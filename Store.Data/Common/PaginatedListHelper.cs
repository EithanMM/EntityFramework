using Microsoft.EntityFrameworkCore;
using Store.Core.Common;

namespace Store.Data.Common;

public static class PaginatedListHelper
{
    public static async Task<PaginatedList<T>> CreateAsync<T>(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellation)
    {
        var count = await source.CountAsync(cancellation);

        var items = await source.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync(cancellation);

        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }
}

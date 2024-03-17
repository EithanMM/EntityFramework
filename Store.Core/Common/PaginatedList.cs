namespace Store.Core.Common;

public sealed class PaginatedList<T>
{
    private readonly int defaultPageSize = 10;

    public List<T> Results { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public bool PreviousPage => PageNumber > 1;
    public bool NextPage => PageNumber < TotalPages;

    public PaginatedList(List<T> results, int count, int pageNumber, int? pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize ?? defaultPageSize;
        TotalPages = (int)Math.Ceiling(count / (double)(PageSize));
        TotalCount = count;
        Results = results;
    }

    public PaginatedList<T> Empty(int? pageSize)
    {
        return new PaginatedList<T>(new List<T>(), 0, 0, pageSize);
    }
}

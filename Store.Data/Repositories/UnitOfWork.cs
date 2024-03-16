using Microsoft.EntityFrameworkCore;

namespace Store.Data.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private DbContext _dbContext { get; init; }

    public UnitOfWork(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<int> CommitAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}

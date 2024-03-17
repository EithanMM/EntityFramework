using Microsoft.EntityFrameworkCore;

namespace Store.Data.Repositories;

public abstract class Repository<TDbContext> : IRepository where TDbContext : DbContext
{
    protected TDbContext DbContext { get;  private set; }
    public IUnitOfWork UnitOfWork { get; private set; }

    protected Repository(TDbContext dbContext, IUnitOfWork? unitOfWork = null)
    {
        DbContext = dbContext;
        UnitOfWork = unitOfWork ?? new UnitOfWork(dbContext);
    }

    public bool HasChanges() => DbContext.ChangeTracker.HasChanges();

    public void Add<T>(T item) where T : class => DbContext.Add(item);

    public void AddRange<T>(IEnumerable<T> items) where T : class => DbContext.AddRange(items);

    public void Remove<T>(T item) where T : class => DbContext.Remove(item);

    public void RemoveRange<T>(IEnumerable<T> items) where T : class => DbContext.RemoveRange(items);

    public void Update<T>(T item) where T : class => DbContext.Update(item);

    public void UpdateRange<T>(IEnumerable<T> items) where T : class => DbContext.UpdateRange(items);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing)
    {
        DbContext.Dispose();
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        DbContext = null;
        UnitOfWork = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }
}

namespace Store.Data.Repositories;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}

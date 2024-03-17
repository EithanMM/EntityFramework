namespace Store.Data.Repositories;

public interface IRepository : IDisposable
{
    IUnitOfWork UnitOfWork { get; }

    /// <summary>
    /// Checks if any new, deleted, or changed entities are being tracked
    /// Changes will be sent to the database if <see cref="IUnitOfWork.CommitAsync" /> is called
    /// </summary>
    /// <returns></returns>
    public bool HasChanges();

    /// <summary>
    /// Adds an item to the context. Record will be saved upon commiting the unit of work
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    void Add<T>(T item) where T : class;

    /// <summary>
    /// Adds a collection of items, Records will be saved upon commiting the unit of work
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    void AddRange<T>(IEnumerable<T> items) where T : class;

    /// <summary>
    /// Updates an item, Item updates will be pesisted upon commiting the unit of work
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    void Update<T>(T item) where T : class;

    /// <summary>
    /// Updates a collection of items, Items updates will be pesisted upon commiting the unit of work
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    void UpdateRange<T>(IEnumerable<T> items)where T : class;

    /// <summary>
    /// Removes an item. Items will be deleted upon commiting the unit of work
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    void Remove<T>(T item) where T : class;

    /// <summary>
    /// Removes a collection of items. Items will be deleted upon commiting the unit of work
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    void RemoveRange<T>(IEnumerable<T> items) where T : class;
}

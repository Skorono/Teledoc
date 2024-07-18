namespace Teledoc.Core.Repositories;

public interface IRepository<T>
    where T : class
{
    public void Add(T entity);

    public Task AddAsync(T entity);

    public void Update(T entity);

    public Task UpdateAsync(T entity);

    public void Remove(T entity);

    public Task RemoveAsync(T entity);

    public T? Get(int id);
    public IEnumerable<T> Get();

    public IEnumerable<T?> Get(Func<T, bool> predicate);

    public Task<T?> GetAsync(int id);

    public Task<IEnumerable<T>> GetAsync();

    public Task<IEnumerable<T>?> GetAsync(Func<T, bool> predicate);
}
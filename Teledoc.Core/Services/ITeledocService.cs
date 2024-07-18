namespace Teledoc.Core.Services;

public interface ITeledocService<T>
{
    public Task<IEnumerable<T>> Get();

    public Task<T>? GetById(int id);

    public Task Add(T entity);

    public Task Update(T entity);

    public Task Remove(int id);
}
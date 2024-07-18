using Teledoc.Core.Repositories;

namespace Teledoc.Core.Services;

public class ServiceBase<T> : ITeledocService<T>
    where T : class
{
    protected readonly EntityRepository<T> _repository;

    public ServiceBase(EntityRepository<T> repository)
    {
        _repository = repository;
    }

    public virtual async Task<IEnumerable<T>> Get()
    {
        return await _repository.GetAsync();
    }

    public virtual async Task<T?> GetById(int id)
    {
        return await _repository.GetAsync(id);
    }

    public virtual async Task Add(T entity)
    {
        await _repository.AddAsync(entity);
    }

    public virtual async Task Update(T entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public virtual async Task Remove(int id)
    {
        await _repository.RemoveAsync(_repository.Get(id));
    }
}
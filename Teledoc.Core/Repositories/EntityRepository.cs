using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Teledoc.Core.Exceptions.Entities;

namespace Teledoc.Core.Repositories;

public abstract class EntityRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected DbContext Context;
    protected DbSet<TEntity> DbSet;
    protected ILogger<EntityRepository<TEntity>> Logger;

    public EntityRepository(DbContext context, ILogger<EntityRepository<TEntity>> logger)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();

        Logger = logger;
    }

    public virtual void Add(TEntity entity)
    {
        if (DbSet.Contains(entity))
            throw new EntityAlreadyExists($"{entity} already exists in {nameof(DbSet.EntityType)} table");

        DbSet.Add(entity);
        Save($"Entity {nameof(entity)} successfully added");
    }

    public async Task AddAsync(TEntity entity)
    {
        await Task.Factory.StartNew(() => Add(entity));
    }

    public virtual void Update(TEntity entity)
    {
        if (!DbSet.Contains(entity))
            throw new EntityNotFound($"{entity} not found in table {nameof(DbSet.EntityType)} table");

        DbSet.Update(entity);
        Save($"Entity {nameof(entity)} successfully updated");
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await Task.Factory.StartNew(() => Update(entity));
    }

    public virtual void Remove(TEntity entity)
    {
        if (!DbSet.Contains(entity))
            throw new EntityNotFound($"{entity} not found in table {nameof(DbSet.EntityType)} table");

        DbSet.Remove(entity);
        Save($"Entity {nameof(entity)} successfully removed");
    }

    public async Task RemoveAsync(TEntity entity)
    {
        await Task.Factory.StartNew(() => Remove(entity));
    }

    public virtual TEntity? Get(int id)
    {
        var entity = DbSet.Find(id);

        if (entity == null)
            throw new EntityNotFound("failed to find entity");

        return entity;
    }

    public virtual IEnumerable<TEntity> Get()
    {
        return DbSet.AsNoTracking();
    }

    public virtual IEnumerable<TEntity?> Get(Func<TEntity, bool> predicate)
    {
        return DbSet.AsNoTracking()
            .AsEnumerable()
            .Where(predicate);
    }

    public async Task<TEntity?> GetAsync(int id)
    {
        return await Task.Factory.StartNew(() => Get(id));
    }

    public async Task<IEnumerable<TEntity>> GetAsync()
    {
        return await Task<IEnumerable<TEntity>>.Factory.StartNew(Get);
    }

    public Task<IEnumerable<TEntity>?> GetAsync(Func<TEntity, bool> predicate)
    {
        return Task<IEnumerable<TEntity>>.Factory.StartNew(() => Get(predicate));
    }

    private void Save(string? message)
    {
        Context.SaveChanges();

        if (message != null)
            Logger.LogInformation(message);
    }
}
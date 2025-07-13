using System.Collections.Concurrent;
using WaterTestProject.Database.Models;

namespace WaterTestProject.Database.Repository;

public class InMemoryRepository<TModelType> : IRepository<TModelType> where TModelType : DbEntity, new()
{
    private static readonly ConcurrentDictionary<Guid, TModelType> Data = new();
    private readonly List<TModelType> _added = [];
    private readonly List<TModelType> _deleted = [];
    private readonly List<TModelType> _updated = [];
    private bool _disposed;

    public IQueryable<TModelType> Query => Data.Values.Where(e => !e.Deleted).AsQueryable();

    public TModelType Get(Guid id)
    {
        return Data.TryGetValue(id, out var entity) && !entity.Deleted ? entity : null;
    }

    public Task<TModelType> GetAsync(Guid id)
    {
        return Task.FromResult(Get(id));
    }

    public void Insert(TModelType entity)
    {
        if (entity.Id == Guid.Empty)
            entity.Id = Guid.NewGuid();
        entity.CreateTime = DateTime.Now;
        _added.Add(entity);
    }

    public Task InsertAsync(TModelType entity)
    {
        Insert(entity);
        return Task.CompletedTask;
    }

    public void Update(TModelType entity)
    {
        _updated.Add(entity);
    }

    public Task UpdateAsync(TModelType entity)
    {
        Update(entity);
        return Task.CompletedTask;
    }

    public void Delete(TModelType entity)
    {
        entity.Deleted = true;
        _deleted.Add(entity);
    }

    public Task DeleteAsync(TModelType entity)
    {
        Delete(entity);
        return Task.CompletedTask;
    }

    public void Commit()
    {
        foreach (var entity in _added)
            Data[entity.Id] = entity;
        foreach (var entity in _updated)
            Data[entity.Id] = entity;
        foreach (var entity in _deleted)
            Data[entity.Id] = entity;
        _added.Clear();
        _updated.Clear();
        _deleted.Clear();
    }

    public Task CommitAsync()
    {
        Commit();
        return Task.CompletedTask;
    }

    public void Rollback()
    {
        _added.Clear();
        _updated.Clear();
        _deleted.Clear();
    }

    public Task RollbackAsync()
    {
        Rollback();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
    }
}
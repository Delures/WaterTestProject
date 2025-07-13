using WaterTestProject.Database.Models;

namespace WaterTestProject.Database.Repository;

public interface IRepository<TModelType> : IDisposable where TModelType : DbEntity
{
    IQueryable<TModelType> Query { get; }
    TModelType Get(Guid id);
    Task<TModelType> GetAsync(Guid id);
    void Insert(TModelType entity);
    Task InsertAsync(TModelType entity);
    void Update(TModelType entity);
    Task UpdateAsync(TModelType entity);
    void Delete(TModelType entity);
    Task DeleteAsync(TModelType entity);
    void Commit();
    Task CommitAsync();
    void Rollback();
    Task RollbackAsync();
}
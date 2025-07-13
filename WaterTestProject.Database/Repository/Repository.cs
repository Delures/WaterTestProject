using NHibernate;
using WaterTestProject.Database.Models;

namespace WaterTestProject.Database.Repository;

/// <summary>
///     Реализация репозитория для работы с сущностями базы данных
/// </summary>
/// <typeparam name="TModelType">Тип модели, должен наследоваться от DbEntity</typeparam>
public sealed class Repository<TModelType> : IRepository<TModelType>
    where TModelType : DbEntity
{
    private readonly ISession _session;

    /// <summary>
    ///     Реализация репозитория для работы с сущностями базы данных
    /// </summary>
    /// <typeparam name="TModelType">Тип модели, должен наследоваться от DbEntity</typeparam>
    public Repository(ISession session)
    {
        _session = session;
    }

    private ITransaction Transaction => _session.BeginTransaction();

    /// <summary>
    ///     Получает запрос для получения всех неудаленных сущностей данного типа
    /// </summary>
    public IQueryable<TModelType> Query => _session.Query<TModelType>().Where(e => !e.Deleted);

    /// <summary>
    ///     Получает сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <returns>Найденная сущность или null, если не найдена</returns>
    public TModelType Get(Guid id)
    {
        return _session.Get<TModelType>(id);
    }

    /// <summary>
    ///     Асинхронно получает сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <returns>Задача, возвращающая найденную сущность или null, если не найдена</returns>
    public async Task<TModelType> GetAsync(Guid id)
    {
        return await _session.GetAsync<TModelType>(id);
    }

    /// <summary>
    ///     Вставляет новую сущность в базу данных
    /// </summary>
    /// <param name="entity">Сущность для вставки</param>
    public void Insert(TModelType entity)
    {
        entity.CreateTime = DateTime.Now;
        _session.Save(entity);
    }

    /// <summary>
    ///     Асинхронно вставляет новую сущность в базу данных
    /// </summary>
    /// <param name="entity">Сущность для вставки</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task InsertAsync(TModelType entity)
    {
        entity.CreateTime = DateTime.Now;
        await _session.SaveAsync(entity);
    }

    /// <summary>
    ///     Обновляет существующую сущность в базе данных
    /// </summary>
    /// <param name="entity">Сущность для обновления</param>
    public void Update(TModelType entity)
    {
        _session.Update(entity);
    }

    /// <summary>
    ///     Асинхронно обновляет существующую сущность в базе данных
    /// </summary>
    /// <param name="entity">Сущность для обновления</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task UpdateAsync(TModelType entity)
    {
        await _session.MergeAsync(entity);
    }

    /// <summary>
    ///     Удаляет сущность из базы данных
    /// </summary>
    /// <param name="entity">Сущность для удаления</param>
    public void Delete(TModelType entity)
    {
        _session.Delete(entity);
    }

    /// <summary>
    ///     Асинхронно удаляет сущность из базы данных
    /// </summary>
    /// <param name="entity">Сущность для удаления</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task DeleteAsync(TModelType entity)
    {
        await _session.DeleteAsync(entity);
    }

    /// <summary>
    ///     Подтверждает транзакцию
    /// </summary>
    public void Commit()
    {
        Transaction.Commit();
    }

    /// <summary>
    ///     Асинхронно подтверждает транзакцию
    /// </summary>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task CommitAsync()
    {
        await Transaction.CommitAsync();
    }

    /// <summary>
    ///     Отменяет транзакцию
    /// </summary>
    public void Rollback()
    {
        Transaction.Rollback();
    }

    /// <summary>
    ///     Асинхронно отменяет транзакцию
    /// </summary>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task RollbackAsync()
    {
        await Transaction.RollbackAsync();
    }

    /// <summary>
    ///     Освобождает ресурсы, связанные с сессией и транзакцией
    /// </summary>
    public void Dispose()
    {
        _session.Dispose();
        Transaction.Dispose();
    }
}
using System.Collections.ObjectModel;
using AutoMapper;
using NHibernate.Linq;
using WaterTestProject.Database.Models;
using WaterTestProject.Database.Repository;

namespace WaterTestProject.Services.DbServices;

public abstract class CrudDbService<TDbModel, TModel>(IRepositoryCreator<TDbModel> repositoryCreator, IMapper mapper) where TDbModel : DbEntity
{
    private readonly IRepository<TDbModel> _repository = repositoryCreator.CreateRepository();

    public async Task<object?> Read(Guid id)
    {
        var foundOrder = await _repository.Query.FirstOrDefaultAsync(order => order.Id == id);
        if (foundOrder != null) 
            mapper.Map<TDbModel, TModel>(foundOrder);
        return null;
    }

    public ObservableCollection<TModel> ReadAll()
    {
        var dbModels = _repository.Query.Select(ord => mapper.Map<TDbModel, TModel>(ord)).ToList();
        return new ObservableCollection<TModel>(dbModels);
    }

    public async Task CreateAsync(TModel model)
    {
        var dbModel = mapper.Map<TModel, TDbModel>(model);
        await _repository.InsertAsync(dbModel);
    }

    public async Task UpdateAsync(TModel model)
    {
        var dbModel = mapper.Map<TModel, TDbModel>(model);
        await _repository.UpdateAsync(dbModel);
    }

    public async Task DeleteAsync(TModel model)
    {
        var dbModel = mapper.Map<TModel, TDbModel>(model);
        dbModel.Deleted = true;
        await _repository.UpdateAsync(dbModel);
    }
    
    public async Task DeleteFromDbAsync(TModel model)
    {
        var dbModel = mapper.Map<TModel, TDbModel>(model);
        await _repository.DeleteAsync(dbModel);
    }

    public async Task CommitAsync() => await _repository.CommitAsync();

    public async Task RollbackAsync() => await _repository.RollbackAsync();

    public async Task SaveAll<TModel>(ObservableCollection<TModel> collection) where TModel : class, new()
    {
        foreach (var model in collection)
        {
            var dbModel = mapper.Map<TModel, TDbModel>(model);
            await _repository.UpdateAsync(dbModel);
        }
        await _repository.CommitAsync();
    }
}
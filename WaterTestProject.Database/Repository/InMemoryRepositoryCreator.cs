using WaterTestProject.Database.Models;

namespace WaterTestProject.Database.Repository;

public class InMemoryRepositoryCreator<TModelType> : IRepositoryCreator<TModelType> where TModelType : DbEntity, new()
{
    public IRepository<TModelType> CreateRepository()
    {
        return new InMemoryRepository<TModelType>();
    }
}
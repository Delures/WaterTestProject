using WaterTestProject.Database.Models;

namespace WaterTestProject.Database.Repository;

public interface IRepositoryCreator<TModelType> where TModelType : DbEntity
{
    IRepository<TModelType> CreateRepository();
}
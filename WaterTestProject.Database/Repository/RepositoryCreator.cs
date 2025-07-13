using NHibernate;
using WaterTestProject.Database.Models;

namespace WaterTestProject.Database.Repository;

public class RepositoryCreator<TModelType>(ISessionFactory sessionFactory) : IRepositoryCreator<TModelType> where TModelType : DbEntity
{
    public IRepository<TModelType> CreateRepository()
    {
        var session = sessionFactory.OpenSession();
        return new Repository<TModelType>(session);
    }
}
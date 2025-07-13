using NHibernate;

namespace WaterTestProject.Database.DataContext;

public interface IDataContextFactory
{
    ISessionFactory CreateSessionFactory();
}
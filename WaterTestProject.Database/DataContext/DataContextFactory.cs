using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using WaterTestProject.Database.Map;
using WaterTestProject.Database.Models;

namespace WaterTestProject.Database.DataContext;

public class DataContextFactory(IConfiguration configuration) : IDataContextFactory
{
    public ISessionFactory CreateSessionFactory()
    {
        var conString = configuration.GetConnectionString("DBConnection");
        var cfg = new Configuration();
        cfg.AddAssembly(typeof(DbEmployee).Assembly);
        cfg.AddAssembly(typeof(DbPartner).Assembly);
        cfg.AddAssembly(typeof(DbOrder).Assembly);
        
        cfg.DataBaseIntegration(props =>
        {
            props.ConnectionString = conString;
            props.Dialect<MySQL8Dialect>();
            props.Driver<MySqlDataDriver>();
            props.ConnectionProvider<DriverConnectionProvider>();
            props.LogSqlInConsole = true;
        });
        
        // Настройка маппингов
        var mapper = new ModelMapper();
        
        // Добавляем все маппинги из сборки
        mapper.AddMappings(typeof(PartnerMap).Assembly.GetTypes());
        mapper.AddMappings(typeof(OrderMap).Assembly.GetTypes());
        mapper.AddMappings(typeof(EmployeeMap).Assembly.GetTypes());
        
        // Компилируем маппинги
        var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
        
        cfg.AddMapping(mapping);
        new NHibernate.Tool.hbm2ddl.SchemaUpdate(cfg).Execute(true, true);
        return cfg.BuildSessionFactory();
    }
}
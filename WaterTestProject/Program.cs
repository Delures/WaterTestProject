using AutoMapper;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NHibernate;
using WaterTestProject.Database.DataContext;
using WaterTestProject.Database.Models;
using WaterTestProject.Database.Repository;
using WaterTestProject.Mapper;
using WaterTestProject.Services.DbServices;
using WaterTestProject.ViewModels;
using WaterTestProject.Views;

namespace WaterTestProject;

public class Program
{
    [STAThread]
    public static void Main()
    {
        // Настраиваем сервисы
        var services = ConfigureServices();

        // Инициализируем IoC-контейнер Community Toolkit
        Ioc.Default.ConfigureServices(services);

        // Запускаем приложение
        var app = Ioc.Default.GetService<App>();
        app?.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Конфигурация и сервисы БД
        services.AddSingleton(ConfigurationLoader.Load());
        services.AddSingleton<IDataContextFactory, DataContextFactory>();
        services.AddSingleton<ISessionFactory>(provider => 
            provider.GetRequiredService<IDataContextFactory>().CreateSessionFactory());
        services.AddScoped<ISession>(provider => 
            provider.GetRequiredService<ISessionFactory>().OpenSession());

        // Репозитории и сервисы
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IRepositoryCreator<>), typeof(RepositoryCreator<>));
        services.AddScoped<EmployeeDbService>();
        services.AddScoped<OrderDbService>();
        services.AddScoped<PartnerDbService>();

        // AutoMapper
        services.AddSingleton(new MapperConfiguration(cfg => 
        {
            cfg.AddProfile<MapperProfile>();
        }, new LoggerFactory()).CreateMapper());

        // ViewModels
        services.AddScoped<MainWindowViewModel>();
        services.AddScoped<OrdersViewModel>();
        services.AddScoped<EmployeesViewModel>();
        services.AddScoped<PartnersViewModel>();

        // Views
        services.AddSingleton<MainWindow>();
        services.AddSingleton<EmployeesView>();
        // services.AddTransient<OrdersView>();
        // services.AddTransient<PartnersView>();

        // App
        services.AddSingleton<App>();

        return services.BuildServiceProvider();
    }
}
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WaterTestProject.Database.Repository;
using WaterTestProject.Mapper;
using WaterTestProject.ViewModels;
using WaterTestProject.Views;

namespace WaterTestProject;

public class DependencyContainer
{
    public static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton(ConfigurationLoader.Load());

        // Регистрация in-memory репозиториев
        services.AddSingleton(typeof(IRepositoryCreator<>), typeof(InMemoryRepositoryCreator<>));

        services.AddSingleton(new MapperConfiguration(cfg => { cfg.AddProfile<MapperProfile>(); }, new LoggerFactory()).CreateMapper());

        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<OrdersViewModel>();
        services.AddTransient<EmployeesViewModel>();
        services.AddTransient<PartnersViewModel>();

        services.AddTransient<MainWindow>();
        // services.AddTransient<OrdersView>();
        services.AddTransient<EmployeesView>();
        // services.AddTransient<PartnersView>();

        return services;
    }
}
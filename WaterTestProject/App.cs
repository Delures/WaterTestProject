using System.Windows;
using WaterTestProject.ViewModels;

namespace WaterTestProject;

public class App(MainWindow mainWindow, MainWindowViewModel mainWindowViewModel) : Application
{
    // через систему внедрения зависимостей получаем объект главного окна
    protected override void OnStartup(StartupEventArgs e)
    {
        mainWindow.DataContext = mainWindowViewModel;
        mainWindow.Show(); // отображаем главное окно на экране
        base.OnStartup(e);
    }
}
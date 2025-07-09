using System.Windows;

namespace WaterTestProject;

public class App(MainWindow mainWindow) : Application
{
    // через систему внедрения зависимостей получаем объект главного окна
    protected override void OnStartup(StartupEventArgs e)
    {
        mainWindow.Show();  // отображаем главное окно на экране
        base.OnStartup(e);
    }
}
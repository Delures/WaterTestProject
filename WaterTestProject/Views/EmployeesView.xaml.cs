using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using WaterTestProject.ViewModels;

namespace WaterTestProject.Views;

public partial class EmployeesView : UserControl
{
    public EmployeesView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetService<EmployeesViewModel>();
    }
}
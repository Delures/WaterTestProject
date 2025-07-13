using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using WaterTestProject.ViewModels;

namespace WaterTestProject.Views
{
    public partial class OrdersView : UserControl
    {
        public OrdersView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<OrdersViewModel>();
        }
    }
} 
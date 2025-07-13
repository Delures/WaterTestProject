using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using WaterTestProject.ViewModels;

namespace WaterTestProject.Views
{
    public partial class PartnersView : UserControl
    {
        public PartnersView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<PartnersViewModel>();
        }
    }
} 
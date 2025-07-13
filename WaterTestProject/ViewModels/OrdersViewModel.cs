using System.Collections.ObjectModel;
using WaterTestProject.Database.Models;
using WaterTestProject.Models;
using WaterTestProject.Services.DbServices;

namespace WaterTestProject.ViewModels;

public class OrdersViewModel(OrderDbService orderDbService, PartnerDbService partnerDbService) : 
    BaseViewModel<DbOrder, OrderModel>(orderDbService)
{
    public ObservableCollection<PartnerModel> Partners => 
        new(partnerDbService.ReadAll().Where(e => !e.Deleted));
}
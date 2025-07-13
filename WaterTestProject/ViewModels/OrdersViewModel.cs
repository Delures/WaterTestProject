using WaterTestProject.Database.Models;
using WaterTestProject.Models;
using WaterTestProject.Services.DbServices;

namespace WaterTestProject.ViewModels;

public class OrdersViewModel(OrderDbService dbService) : BaseViewModel<DbOrder, OrderModel>(dbService);
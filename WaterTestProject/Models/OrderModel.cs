using CommunityToolkit.Mvvm.ComponentModel;

namespace WaterTestProject.Models;

public partial class OrderModel : BaseModel
{
    [ObservableProperty] private DateTime _orderDate = DateTime.Now;
    [ObservableProperty] private decimal _total;
    [ObservableProperty] private PartnerModel? _partner;
    public EmployeeModel? Supervisor => Partner?.Supervisor;
}
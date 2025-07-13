using CommunityToolkit.Mvvm.ComponentModel;

namespace WaterTestProject.Models;

public partial class OrderModel : BaseModel
{
    [ObservableProperty] private DateTime _orderDate = DateTime.Now;
    private PartnerModel? _partner;
    private EmployeeModel? _supervisor;
    [ObservableProperty] private decimal _total;

    public PartnerModel? Partner
    {
        get => _partner;
        set
        {
            SetProperty(ref _partner, value);
            Supervisor = _partner?.Supervisor;
        }
    }

    public EmployeeModel? Supervisor
    {
        get => _supervisor;
        private set => SetProperty(ref _supervisor, value);
    }
}
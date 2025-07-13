using CommunityToolkit.Mvvm.ComponentModel;

namespace WaterTestProject.Models;

public partial class PartnerModel : BaseModel
{
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private string _taxpayerIdentificationNumber = string.Empty;
    [ObservableProperty] private EmployeeModel? _supervisor;
}
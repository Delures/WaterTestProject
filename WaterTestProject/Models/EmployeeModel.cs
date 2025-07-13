using CommunityToolkit.Mvvm.ComponentModel;
using WaterTestProject.Common.Enums;

namespace WaterTestProject.Models;

public partial class EmployeeModel : BaseModel
{
    [ObservableProperty] private string _firstName = string.Empty;
    [ObservableProperty] private string _lastName = string.Empty;
    [ObservableProperty] private string _patronymic = string.Empty;
    [ObservableProperty] private EmployeePosition _position = EmployeePosition.None;
    [ObservableProperty] private DateTime? _dateOfBirth;
}
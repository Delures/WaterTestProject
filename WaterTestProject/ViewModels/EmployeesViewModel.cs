using System.Collections.ObjectModel;
using WaterTestProject.Common.Enums;
using WaterTestProject.Database.Models;
using WaterTestProject.Models;
using WaterTestProject.Services.DbServices;

namespace WaterTestProject.ViewModels;

public class EmployeesViewModel(EmployeeDbService orderDbService) : BaseViewModel<DbEmployee, EmployeeModel>(orderDbService)
{
    public ObservableCollection<EmployeePosition> Positions { get; } = new(Enum.GetValues<EmployeePosition>().ToList());
}
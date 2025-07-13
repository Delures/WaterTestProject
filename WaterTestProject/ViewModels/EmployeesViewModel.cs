using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WaterTestProject.Common.Enums;
using WaterTestProject.Database.Models;
using WaterTestProject.Models;
using WaterTestProject.Services.DbServices;

namespace WaterTestProject.ViewModels;

public class EmployeesViewModel(EmployeeDbService dbService) : BaseViewModel<DbEmployee, EmployeeModel>(dbService)
{
    public ObservableCollection<EmployeePosition> Positions { get; } = new(Enum.GetValues<EmployeePosition>().ToList());
}
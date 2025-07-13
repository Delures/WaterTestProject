using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WaterTestProject.Common.Enums;
using WaterTestProject.Database.Models;
using WaterTestProject.Models;
using WaterTestProject.Services.DbServices;

namespace WaterTestProject.ViewModels;

public partial class PartnersViewModel(PartnerDbService orderDbService, EmployeeDbService employeeDbService) : BaseViewModel<DbPartner, PartnerModel>(orderDbService)
{
    public ObservableCollection<EmployeeModel> Employees => 
        new(employeeDbService.ReadAll().Where(e => !e.Deleted && e.Position is EmployeePosition.Manager));
}
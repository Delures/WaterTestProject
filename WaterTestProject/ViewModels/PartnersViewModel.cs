using System.Collections.ObjectModel;
using WaterTestProject.Common.Enums;
using WaterTestProject.Database.Models;
using WaterTestProject.Models;
using WaterTestProject.Services.DbServices;

namespace WaterTestProject.ViewModels;

public class PartnersViewModel(PartnerDbService orderDbService, EmployeeDbService employeeDbService) : BaseViewModel<DbPartner, PartnerModel>(orderDbService)
{
    public ObservableCollection<EmployeeModel> Employees =>
        new(employeeDbService.ReadAll().Where(e => !e.Deleted && e.Position is EmployeePosition.Manager));
}
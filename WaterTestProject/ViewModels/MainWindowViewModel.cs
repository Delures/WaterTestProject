using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WaterTestProject.Models;
using WaterTestProject.Services.DbServices;

namespace WaterTestProject.ViewModels;

public class MainWindowViewModel(EmployeeDbService employeeDbService, OrderDbService orderDbService, PartnerDbService partnerDbService);
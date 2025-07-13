using WaterTestProject.Database.Models;
using WaterTestProject.Models;
using WaterTestProject.Services.DbServices;

namespace WaterTestProject.ViewModels;

public class PartnersViewModel(PartnerDbService dbService) : BaseViewModel<DbPartner, PartnerModel>(dbService);
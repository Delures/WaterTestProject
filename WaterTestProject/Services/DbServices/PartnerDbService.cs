using System.Collections.ObjectModel;
using AutoMapper;
using WaterTestProject.Database.Models;
using WaterTestProject.Database.Repository;
using WaterTestProject.Models;

namespace WaterTestProject.Services.DbServices;

public class PartnerDbService(IRepositoryCreator<DbPartner> repositoryCreator, IMapper mapper) : 
    CrudDbService<DbPartner, PartnerModel>(repositoryCreator, mapper);
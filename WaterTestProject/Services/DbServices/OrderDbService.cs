using System.Collections.ObjectModel;
using AutoMapper;
using WaterTestProject.Database.Models;
using WaterTestProject.Database.Repository;
using WaterTestProject.Models;

namespace WaterTestProject.Services.DbServices;

public class OrderDbService(IRepositoryCreator<DbOrder> repositoryCreator, IMapper mapper) : 
    CrudDbService<DbOrder, OrderModel>(repositoryCreator, mapper);
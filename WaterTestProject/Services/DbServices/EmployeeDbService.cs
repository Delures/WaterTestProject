using System.Collections.ObjectModel;
using AutoMapper;
using WaterTestProject.Database.Models;
using WaterTestProject.Database.Repository;
using WaterTestProject.Models;

namespace WaterTestProject.Services.DbServices;

public class EmployeeDbService(IRepositoryCreator<DbEmployee> repositoryCreator, IMapper mapper) : 
    CrudDbService<DbEmployee, EmployeeModel>(repositoryCreator, mapper);
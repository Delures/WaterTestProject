using AutoMapper;
using WaterTestProject.Database.Models;
using WaterTestProject.Models;

namespace WaterTestProject.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<DbEmployee, EmployeeModel>()
            .ReverseMap();

        CreateMap<DbOrder, OrderModel>()
            .ReverseMap();

        CreateMap<DbPartner, PartnerModel>()
            .ReverseMap();
    }
}
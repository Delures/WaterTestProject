using NHibernate.Mapping.ByCode.Conformist;
using WaterTestProject.Database.Models;

namespace WaterTestProject.Database.Map;

public class EmployeeMap : ClassMapping<DbEmployee>
{
    public EmployeeMap()
    {
        Id(emp => emp.Id);
        Property(emp => emp.Deleted);
        Property(emp => emp.FirstName);
        Property(emp => emp.LastName);
        Property(emp => emp.Patronymic);
        Property(emp => emp.Position);
        Property(emp => emp.DateOfBirth);
    }
}
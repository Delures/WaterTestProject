using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WaterTestProject.Database.Models;

namespace WaterTestProject.Database.Map;

public class OrderMap : ClassMapping<DbOrder>
{
    public OrderMap()
    {
        Id(order => order.Id);
        Property(order => order.Deleted);
        Property(order => order.OrderDate);
        Property(order => order.Total);
        ManyToOne(order => order.Partner, m => { m.Cascade(Cascade.None); });
    }
}
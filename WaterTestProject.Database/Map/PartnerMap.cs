using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WaterTestProject.Database.Models;

namespace WaterTestProject.Database.Map;

public class PartnerMap : ClassMapping<DbPartner>
{
    public PartnerMap()
    {
        Id(partner => partner.Id);
        Property(partner => partner.Deleted);
        Property(partner => partner.Name);
        Property(partner => partner.TaxpayerIdentificationNumber);

        // Связь с курирующим сотрудником
        ManyToOne(partner => partner.Supervisor, m =>
        {
            m.Column("SupervisorId");
            m.Cascade(Cascade.None);
        });
    }
}
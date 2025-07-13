namespace WaterTestProject.Database.Models;

public class DbPartner : DbEntity
{
    public virtual string Name { get; set; }
    public virtual string TaxpayerIdentificationNumber { get; set; }
    public virtual DbEmployee? Supervisor { get; set; }
}
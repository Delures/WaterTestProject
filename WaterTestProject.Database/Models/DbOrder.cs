namespace WaterTestProject.Database.Models;

public class DbOrder : DbEntity
{
    public virtual DateTime OrderDate { get; set; }
    public virtual decimal Total { get; set; }
    public virtual DbPartner? Partner { get; set; }
}
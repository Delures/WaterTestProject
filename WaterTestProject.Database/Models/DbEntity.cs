namespace WaterTestProject.Database.Models;

public abstract class DbEntity
{
    public virtual Guid Id { get; set; }
    
    public virtual bool Deleted { get; set; }
    
    public virtual DateTime CreateTime { get; set; }
}
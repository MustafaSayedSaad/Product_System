namespace Product_System.Domain.Models;

public abstract class BaseEntity : IBaseEntity
{
    public bool IsDeleted { get; set; } = false;
    public DateTime? InsertDate { get; set; } 
    public DateTime? UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }

    public string? InsertBy { get; set; }
    public string? UpdateBy { get; set; }
    public string? DeleteBy { get; set; }
    public bool IsActive { get; set; } = true;
}

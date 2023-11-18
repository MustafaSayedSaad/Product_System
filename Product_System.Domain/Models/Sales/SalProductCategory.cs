namespace Product_System.Domain.Models.Sales;

[Table("Sal_ProductCategories")]
public class SalProductCategory : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<SalProduct> ListOfProducts { get; set; } = new HashSet<SalProduct>();
}

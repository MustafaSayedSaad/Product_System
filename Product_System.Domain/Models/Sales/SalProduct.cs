namespace Product_System.Domain.Models.Sales;

[Table("Sal_Products")]
public class SalProduct : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public double DurationInHour { get; set; }
    public double Price { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public string ImageExtension { get; set; } = string.Empty;

    public int ProductCategoryId { get; set; }
    [ForeignKey(nameof(ProductCategoryId))]
    public SalProductCategory ProductCategory { get; set; } = default!;
}

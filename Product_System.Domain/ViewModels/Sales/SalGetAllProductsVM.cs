namespace Product_System.Domain.ViewModels.Sales;

public class SalGetAllProductsVM
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public double DurationInHour { get; set; }
    public double Price { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public string ImageExtension { get; set; } = string.Empty;
    public string ProductCategoryName { get; set; } = string.Empty;
    public int ProductCategoryId { get; set; }
}
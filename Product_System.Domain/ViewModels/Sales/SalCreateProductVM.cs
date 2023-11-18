using Microsoft.AspNetCore.Mvc.Rendering;

namespace Product_System.Domain.ViewModels.Sales;

public class SalCreateProductVM 
{
    public string Name { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public double DurationInHour { get; set; }
    public double Price { get; set; }

    [RequiredExtensions(FileSettings.RequiredExtensions),
    MaximumSize(FileSettings.MaxFileSizeInBytes)]
    public IFormFile ImagePath { get; set; } = default!;
    public int ProductCategoryId { get; set; }

    public IEnumerable<SelectListItem> ProductsCategories { get; set; } = Enumerable.Empty<SelectListItem>();

}
namespace Product_System.Domain.ViewModels.Sales;

public class SalUpdateProductVM : SalCreateProductVM
{
    public int Id { get; set; }
    public string ImageName { get; set; } = string.Empty;
}
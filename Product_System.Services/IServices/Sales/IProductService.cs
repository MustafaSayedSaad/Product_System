namespace Product_System.Services.IServices.Sales;

public interface IProductService
{
    Task<IEnumerable<SelectListItem>> ListOfProductsCategoriesAsync();
    Task<IEnumerable<SalGetAllProductsVM>> GetAllProductsAsync(int productCategoryId);
    Task CreateProductAsync(SalCreateProductVM model);
    Task<SalGetProductByIdVM> GetProductByIdAsync(int id);
    Task<SalUpdateProductVM> UpdateProductAsync(int id, SalUpdateProductVM model);
    Task<bool> DeleteProductAsync(int id);
}

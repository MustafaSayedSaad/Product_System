namespace Product_System.Domain.Interfaces.StaticDataRepository;

public interface IStaticDataRepository 
{
    IEnumerable<SelectListItem> GetAllProductsCategories();
}

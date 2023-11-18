namespace Product_System.DataAccess.Repositories.Sales;

public class ProductRepository(ProductDbContext context) : BaseRepository<SalProduct>(context), IProductRepository
{
}

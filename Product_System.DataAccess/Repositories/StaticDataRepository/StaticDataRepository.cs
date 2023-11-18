namespace Product_System.DataAccess.Repositories.StaticDataRepository;

public class StaticDataRepository(ProductDbContext context) : IStaticDataRepository
{
    private readonly ProductDbContext _context = context;

    public IEnumerable<SelectListItem> GetAllProductsCategories() =>
         _context.ProductCategories.AsNoTracking().Select(x => new SelectListItem 
         {
             Value = x.Id.ToString(),
             Text = x.Name 
         });

}

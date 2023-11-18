namespace Product_System.DataAccess.Repositories.Auth;

public class RoleRepository : BaseRepository<ApplicationRole>, IRoleRepository
{
    public RoleRepository(ProductDbContext context) : base(context)
    {
    }
}

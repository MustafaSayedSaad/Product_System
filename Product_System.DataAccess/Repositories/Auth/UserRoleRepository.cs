namespace Product_System.DataAccess.Repositories.Auth;

public class UserRoleRepository : BaseRepository<ApplicationUserRole>, IUserRoleRepository
{
    public UserRoleRepository(ProductDbContext context) : base(context)
    {
    }
}

namespace Product_System.DataAccess.Repositories.Auth;

public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
{
    public UserRepository(ProductDbContext context) : base(context)
    {
    }
}

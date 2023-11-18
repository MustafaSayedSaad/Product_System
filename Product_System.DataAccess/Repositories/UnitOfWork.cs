namespace Product_System.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductDbContext _context;
    protected readonly IConfiguration _config;

    public IUserRepository Users { get; private set; }
    public IRoleRepository Roles { get; private set; }
    public IUserRoleRepository UserRoles { get; private set; }
    public IProductRepository Products { get; private set; }

    public UnitOfWork(ProductDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;

        Users = new UserRepository(_context);
        Roles = new RoleRepository(_context);
        UserRoles = new UserRoleRepository(_context);
        Products = new ProductRepository(_context);
    }

    public IDatabaseTransaction BeginTransaction() =>
        new EntityDatabaseTransaction(_context);

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();

    public int Complete() => _context.SaveChanges();
}

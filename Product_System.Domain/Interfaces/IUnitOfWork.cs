using Product_System.Domain.Interfaces.Sales;

namespace Product_System.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IDatabaseTransaction BeginTransaction();

    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IUserRoleRepository UserRoles { get; }
    IProductRepository Products { get; }
    Task<int> CompleteAsync();
}

namespace Product_System.DataAccesss.DbContext;

public class ProductDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
    ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
     ApplicationRoleClaim, ApplicationUserToken>
{
    public IHttpContextAccessor Accessor { get; set; }

    public ProductDbContext(DbContextOptions<ProductDbContext> options, IHttpContextAccessor accessor) : base(options) =>
        Accessor = accessor;


    #region Data Sets

    public DbSet<ComLog> Logs { get; set; }
    public DbSet<SalProduct> Products { get; set; }
    public DbSet<SalProductCategory> ProductCategories { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SeedData();
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.AddQueryFilterToAllEntitiesAssignableFrom<BaseEntity>(x => x.IsDeleted == false);
        modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()).ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.NoAction);

        modelBuilder.Entity<ApplicationUser>().ToTable("Auth_Users", "dbo");
        modelBuilder.Entity<ApplicationRole>().ToTable("Auth_Roles", "dbo");
        modelBuilder.Entity<ApplicationUserRole>().ToTable("Auth_UserRoles", "dbo");
        modelBuilder.Entity<ApplicationUserClaim>().ToTable("Auth_UserClaims", "dbo");
        modelBuilder.Entity<ApplicationUserLogin>().ToTable("Auth_UserLogins", "dbo");
        modelBuilder.Entity<ApplicationRoleClaim>().ToTable("Auth_RoleClaims", "dbo");
        modelBuilder.Entity<ApplicationUserToken>().ToTable("Auth_UserTokens", "dbo");
    }

    //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    //{
    //    //DateTime dateNow = new DateTime().NowEg();
    //    //string userId = Accessor!.HttpContext == null ? string.Empty : Accessor!.HttpContext!.User.GetUserId();

    //    var entries = ChangeTracker
    //        .Entries()
    //        .Where(e => e.Entity is BaseEntity && (
    //                e.State == EntityState.Added
    //                || e.State == EntityState.Modified
    //                || e.State == EntityState.Deleted)
    //    );
    //    foreach (var entityEntry in entries)
    //    {
    //        ((BaseEntity)entityEntry.Entity).UpdateDate = dateNow;
    //        ((BaseEntity)entityEntry.Entity).UpdateBy = userId;

    //        if (entityEntry.State == EntityState.Added)
    //        {
    //            ((BaseEntity)entityEntry.Entity).InsertDate = dateNow;
    //            ((BaseEntity)entityEntry.Entity).InsertBy = userId;
    //        }
    //        if (entityEntry.State == EntityState.Deleted)
    //        {
    //            entityEntry.State = EntityState.Modified;
    //            ((BaseEntity)entityEntry.Entity).DeleteDate = dateNow;
    //            ((BaseEntity)entityEntry.Entity).DeleteBy = userId;
    //            ((BaseEntity)entityEntry.Entity).IsDeleted = true;
    //        }
    //    }
    //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    //}
}

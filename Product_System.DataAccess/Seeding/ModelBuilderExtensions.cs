namespace Product_System.DataAccess.Seeding;

public static class ModelBuilderExtensions
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        #region Users and their roles

        modelBuilder.Entity<ApplicationRole>()
            .HasData(
            new ApplicationRole()
            {
                Id = Admin.RoleId,
                Name = RolesEnums.Admin.ToString(),
                ConcurrencyStamp = "1",
                NormalizedName = "ADMIN"
            });

        modelBuilder.Entity<ApplicationUser>()
            .HasData(
            new ApplicationUser()
            {
                Id = Admin.Id,
                UserName = "David",
                NormalizedUserName = "DAVID",
                Email = "david88@gmail.com",
                NormalizedEmail = "DAVID88@GMAIL.COM",
                EmailConfirmed = true,
                IsActive = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, Admin.Password)
            }
            );

        modelBuilder.Entity<ApplicationUserRole>()
            .HasData(
           new ApplicationUserRole()
           {
               RoleId = Admin.RoleId,
               UserId = Admin.Id
           });

        #endregion

        modelBuilder.Entity<SalProductCategory>()
            .HasData(
           new SalProductCategory() { Id = 1, Name = "Electrical products" },
           new SalProductCategory() { Id = 2, Name = "Food products" });
    }

    public static void AddQueryFilterToAllEntitiesAssignableFrom<T>(this ModelBuilder modelBuilder,
     Expression<Func<T, bool>> expression)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(T).IsAssignableFrom(entityType.ClrType))
                continue;

            var parameterType = Expression.Parameter(entityType.ClrType);
            var expressionFilter = ReplacingExpressionVisitor.Replace(
                expression.Parameters.Single(), parameterType, expression.Body);

            var currentQueryFilter = entityType.GetQueryFilter();
            if (currentQueryFilter != null)
            {
                var currentExpressionFilter = ReplacingExpressionVisitor.Replace(
                    currentQueryFilter.Parameters.Single(), parameterType, currentQueryFilter.Body);
                expressionFilter = Expression.AndAlso(currentExpressionFilter, expressionFilter);
            }

            var lambdaExpression = Expression.Lambda(expressionFilter, parameterType);
            entityType.SetQueryFilter(lambdaExpression);
        }
    }
}

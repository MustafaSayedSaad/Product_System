using Microsoft.EntityFrameworkCore;
using Product_System.DataAccesss.DbContext;
using Product_System.Domain.Interfaces.Logging;
using Product_System.Services.IServices.Auth;
using Product_System.Services.Services.Auth;
using Product_System.Services.Services.Sales;
using Product_System.Domain.Customization.Middleware;
using Product_System.DataAccess.Repositories.Logging;
using Product_System.DataAccess.Repositories.StaticDataRepository;
using Product_System.DataAccess.Repositories;
using Product_System.Domain.Interfaces.StaticDataRepository;
using Product_System.Domain.Interfaces;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<ProductDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString(Shared.ProductSystemConnection)));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<ProductDbContext>();
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var connectionString = builder.Configuration.GetConnectionString("ProductSystemConnection")
                                ?? throw new InvalidOperationException("No connection string was found");

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

#region DI

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandlerService>();
//builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProviderService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILoggingRepository, LoggingRepository>();
builder.Services.AddScoped<IStaticDataRepository, StaticDataRepository>();

#endregion

var app = builder.Build();

# region To take an instance from specific repository

var scopedFactory1 = app.Services.GetService<IServiceScopeFactory>();
using var scope1 = scopedFactory1!.CreateScope();
ILoggingRepository loggingRepository = scope1.ServiceProvider.GetService<ILoggingRepository>()!;

#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.ConfigureExceptionHandler(loggingRepository);    // custom as a global exception

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

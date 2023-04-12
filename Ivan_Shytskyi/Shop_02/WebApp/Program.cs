using BLL.Services;
using BLL.Services.Interfaces;
using Contracts.Models;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
                          options.UseNpgsql(configuration.GetConnectionString("pg_FP"), b => b.MigrationsAssembly("WebApp")));

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
});

//builder.Services.AddScoped<MySignInManager>();

builder.Services.AddScoped<IMyAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<ICourierRepository, СourierRepository>();
builder.Services.AddScoped<ICourierService, CourierService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IStoregeRepository, StoregeRepository>();
builder.Services.AddScoped<IStoregeService, StoregeService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDefaultIdentity<User>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddSignInManager<SignInManager<User>>();


builder.Services.AddControllersWithViews();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = "myapp",
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT_Key"]))
//            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetConnectionString("JWT_Key")))
//        };
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


using BLL.Services;
using BLL.Services.Interfaces;
using Contracts.Models;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
                          options.UseNpgsql("Server=host.docker.internal;Port=32768;Database=Final_Project;User Id=postgres;Password=postgrespw;"));

builder.Services.AddScoped<IAdminRepository<Admin>, AdminRepository>();
builder.Services.AddScoped<IAdminService<Admin>, AdminService>();

builder.Services.AddScoped<ICourierRepository<Сourier>, СourierRepository>();
builder.Services.AddScoped<ICourierService<Сourier>, CourierService>();

builder.Services.AddScoped<IOrderRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IOrderService<Order>, OrderService>();

builder.Services.AddScoped<IProductRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IProductService<Product>, ProductService>();

builder.Services.AddScoped<IStoregeRepository<Storege>, StoregeRepository>();
builder.Services.AddScoped<IStoregeService<Storege>, StoregeService>();

builder.Services.AddScoped<IUserRepository<User>, UserRepository>();
builder.Services.AddScoped<IUserService<User>, UserService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


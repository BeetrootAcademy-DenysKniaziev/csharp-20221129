using Lesson35.Classwork.Filters;
using Lesson35.Classwork.Middlewares;
using Lesson35.Classwork.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    //options.Filters.Add<LoggingFilter>();
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql("Server=host.docker.internal;Port=32768;Database=shop_new;User Id=postgres;Password=postgrespw;"));



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

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("LOG FROM MIDDLEWARE BEFORE!");
//    await next(context);
//    Console.WriteLine("LOG FROM MIDDLEWARE AFTER!");
//});

app.UseMiddleware<LoggingMiddleware>();

app.Run();

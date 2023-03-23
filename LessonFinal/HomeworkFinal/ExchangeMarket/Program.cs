using ExchangeMarket.DAL;
using Microsoft.OpenApi.Models;
//using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using ExchangeMarket.Filters;
using ExchangeMarket.Middlewares;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BAL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Contracts;
//using BAL;
using BAL.Interfaces;
using System.Configuration;
using System.Data.Entity;
using BAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HealthChecks;
using MyHealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
//using HealthChecks.Npgsql;
//using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ExchangeMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("log.json", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

            //var dbContext = new DAL.MarketContext();
            //dbContext.Database.EnsureCreated();//Zakomenyuvav, tomu scho inakshe pislya koznogo perehodu PC v sleep mode vidvaluetsya docker i ne perestartovue normalno bez perezavantazhennya

            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddHealthChecks()
                    .AddCheck("MyCustomCheck", () =>
                    {
                        var result = false;
                        var status = result ? HealthStatus.Healthy : HealthStatus.Unhealthy;
                        var message = result ? "Custom check succeeded" : "Custom check failed";
                        return new HealthCheckResult(status, message);
                    })
                .AddUrlGroup(new Uri("http://localhost:5050"), name: "MyUrlCheck")
                .AddNpgSql(configuration.GetConnectionString("DefaultConnection"))
                .AddCheck("Database Select", new MarketContextHealthCheck(new MarketContext(new DbContextOptionsBuilder<MarketContext>()
                .UseNpgsql(configuration.GetConnectionString(nameof(MarketContext)))
                .Options)));


            builder.Services.AddDbContext<MarketContext>();

            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<ITagService, TagService>();

            builder.Services.AddScoped<IRepository<Person>, Repository<Person>>();
            builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
            builder.Services.AddScoped<IRepository<Item>, Repository<Item>>();
            builder.Services.AddScoped<IRepository<Tag>, Repository<Tag>>();

            builder.Services.AddControllersWithViews();


            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Market API", Version = "v1" });
            });

            //builder.Services.AddTransient<TokenMiddleware>();
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,//"myapp"
            //            //ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,//
            //            ValidIssuer = "MyApp",
            //            //ValidAudience = "your-audience",
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt_Key"))
            //        };
            //    });

            //builder.Services.AddIdentity<Contracts.Person, IdentityRole>()
            //    .AddEntityFrameworkStores<MarketContext>()
            //    .AddDefaultTokenProviders();

            builder.Services.AddAuthentication("Cookies")
                .AddCookie("Cookies", options =>
                {
                    options.LoginPath = "/Login/Index";
                    options.AccessDeniedPath = "/AccessDenied";
                });

            builder.Services.AddAuthorization();

            builder.Services.AddScoped<MyIAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IPasswordHasher<Person>, PasswordHasher<Person>>();


            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(LoggingFilter));
            });


            var app = builder.Build();

            //Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            // app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            // app.UseHsts();
            //}
            //else
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseMiddleware<ExceptionGeneratingMiddleware>();



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMiddleware<TokenMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
        //name: "default",
        //    pattern: "{controller=Home}/{action=Index}/{id?}");
        });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMiddleware<LoggingMiddleware>();

            // Use health checks
            //app.UseHealthChecks("/health");
            app.UseEndpoints(endpoints =>
            {
                // Map health checks to /healthchecks
                endpoints.MapHealthChecks("/healthchecks");

                // Map MyUrlCheck to /myurlcheck
                endpoints.MapHealthChecks("/myurlcheck", new HealthCheckOptions
                {
                    Predicate = check => check.Name == "MyUrlCheck"
                });

                // Map Database Select check to /dbcheck
                endpoints.MapHealthChecks("/dbcheck", new HealthCheckOptions
                {
                    Predicate = check => check.Name == "Database Select"
                });

                // Map Database Select check to /MyCustomCheck
                endpoints.MapHealthChecks("/MyCustomCheck", new HealthCheckOptions
                {
                    Predicate = check => check.Name == "MyCustomCheck"
                });
            });

            app.Run();
            Log.CloseAndFlush();
        }
    }
}

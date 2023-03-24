using LearningSystem.BLL.Services;
using LearningSystem.DAL.Repositories;
using LearningSystem.WEB.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);
builder.Services.AddSession();


    
var services = builder.Services;
var configuration = builder.Configuration;


services.AddScoped<IArcticlesService, ArticlesService>();
services.AddScoped<ICoursesService, CoursesService>();
services.AddScoped<ICommentsService, CommentsService>();
services.AddScoped<IUsersServices, UsersService>();
services.AddScoped<ILikeCommentService, LikeCommentService>();
services.AddScoped<ILikeArticleService, LikeArticleService>();
services.AddScoped<IUsersRepository, UsersRepository>();
services.AddScoped<ICoursesRepository, CoursesRepository>();
services.AddScoped<IArticlesRepository, ArticlesRepository>();
services.AddScoped<ICommentsRepository, CommentsRepository>();
services.AddScoped<ILikeArticleRepository, LikeArcticleRepository>();
services.AddScoped<ILikeCommentRepository, LikeCommentRepository>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "myapp",
            ValidAudience = "myapp",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt_Key"]))
        };
    });







var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseMiddleware<AuthMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

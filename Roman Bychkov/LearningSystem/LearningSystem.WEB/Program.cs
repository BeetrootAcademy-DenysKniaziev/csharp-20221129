
using LearningSystem.BLL.Interfaces;
using LearningSystem.BLL.Services;
using LearningSystem.DAL;
using LearningSystem.DAL.Interfaces;
using LearningSystem.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

var services = builder.Services;
var configuration = builder.Configuration;


services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Jwt").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});




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

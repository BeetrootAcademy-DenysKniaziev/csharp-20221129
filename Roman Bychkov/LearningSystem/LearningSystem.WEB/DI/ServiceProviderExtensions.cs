using LearningSystem.BLL.Services;
using LearningSystem.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using LearningSystem.WEB.Mapper;

namespace LearningSystem.WEB.DI
{
    public static class ServiceProviderExtensions
    {
        public static void AddTimeService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IArticlesService, ArticlesService>();
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
            services.AddAutoMapper(typeof(MapperCourse), typeof(MapperLesson), typeof(MapperRegistration));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
        }
    }
}

using DriveSystemWebApplication.DtosManger.FileDtoManger;
using DriveSystemWebApplication.DtosManger.FileDtoManger.FileDtos;
using DriveSystemWebApplication.DtosManger.UserDtosManager;
using DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos;
using DriveSystemWebApplication.Models;
using DriveSystemWebApplication.Repository.FileRepository;
using DriveSystemWebApplication.Repository.UserRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore; 

namespace DriveSystemWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
           .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
           {
               options.LoginPath = "/api/auth/login";
               options.LogoutPath = "/api/auth/signout";

           });
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DriveDbContext>(options =>
                  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));

            builder.Services.AddScoped<IFileRepository, FileRepository>();
            builder.Services.AddScoped<IFileDtoManger, FileDtoManger>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserDtoManger, UserDtoManager>();
          
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowClientAccess",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

using DriveSystemWebApplication.DtosManger.FileDtoManger;
using DriveSystemWebApplication.DtosManger.FileDtoManger.FileDtos;
using DriveSystemWebApplication.DtosManger.UserDtosManager;
using DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos;
using DriveSystemWebApplication.Middelware;
using DriveSystemWebApplication.Models;
using DriveSystemWebApplication.Repository.FileRepository;
using DriveSystemWebApplication.Repository.TokenBlacklistRepository;
using DriveSystemWebApplication.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace DriveSystemWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DriveDbContext>(options =>
                  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));

            builder.Services.AddScoped<IFileRepository, FileRepository>();
            builder.Services.AddScoped<IFileDtoManger, FileDtoManger>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserDtoManger, UserDtoManager>();

            builder.Services.AddTransient<TokenManagerMiddleware>();
            builder.Services.AddSingleton<ITokenReposiatory, TokenRepository>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost";
            });

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
            builder.Services.AddAuthentication(options => options.DefaultAuthenticateScheme = "DriveScheme")
              .AddJwtBearer("DriveScheme", options =>
              {
                  string secretKey = "DriveWebAppAPIDevelopedByCodid";
                  var encodedSecretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      IssuerSigningKey = encodedSecretKey,
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero
                  };
              });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseCors("AllowClientAccess");

            app.UseAuthentication();

            app.UseMiddleware<TokenManagerMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
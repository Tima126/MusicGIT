using Domain.Interfaces;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using DataAccess.Wrapper;
using Domain.Models;
using Domain.Wrapper;

namespace API_Music
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BandList_dbContext>(
             options => options.UseSqlServer(builder.Configuration["ConnectionString"]));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserFavoriteService, UserFavoriteService>();
            builder.Services.AddScoped<ISongListService, SongListService>();
            builder.Services.AddScoped<IReleaseTypeService, ReleaseTypeService>();
            builder.Services.AddScoped<IReleaseListService, ReleaseListService>();
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<IGenreListService, GenreListService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<IBandMemberService, BandMemberService>();
            builder.Services.AddScoped<IBandListService, BandListService>();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Настройка CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient", policy =>
                {
                    policy.WithOrigins("https://musicgit-2.onrender.com") // Укажите ваш Blazor-клиент
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<BandList_dbContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Используйте настроенную политику CORS
            app.UseCors("AllowBlazorClient");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
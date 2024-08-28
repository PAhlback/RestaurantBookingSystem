
using Microsoft.EntityFrameworkCore;
using RestaurantBookingSystem.Data;
using RestaurantBookingSystem.Data.Repos;
using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Services;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            DotNetEnv.Env.Load();
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // REPOS
            builder.Services.AddScoped<IMenuItemsRepo, MenuItemsRepo>();
            builder.Services.AddScoped<ITablesRepo, TablesRepo>();
            builder.Services.AddScoped<ICustomersRepo, CustomersRepo>();

            // SERVICES
            builder.Services.AddScoped<IMenuItemsService, MenuItemsService>();
            builder.Services.AddScoped<ITablesService, TablesService>();
            builder.Services.AddScoped<ICustomersService, CustomersService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

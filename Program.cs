using System.Text.Json;
using LokaverkefniRestaurant.Data;
using LokaverkefniRestaurant.Data.Interfaces;
using LokaverkefniRestaurant.Data.Repository;
using LokaverkefniRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaverkefniRestaurant;

public static class Program
{
    public static void Main(string[] args)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddScoped<IRepository, RestaurantRepository>();
        builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
        
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

        });
        
        
            var app = builder.Build();

            app.UseCors(MyAllowSpecificOrigins);

            // app.UseHttpsRedirection();

            app.UseAuthorization();
        
            app.MapControllers();

            app.Run();
        
    }
}
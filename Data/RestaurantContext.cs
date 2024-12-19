using LokaverkefniRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaverkefniRestaurant.Data;

public class RestaurantContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Drink> Drinks { get; set; }
    
    
    public string DbPath { get; }

    public RestaurantContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "restaurant.db");
        Console.WriteLine(DbPath); 
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");


   /* protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne<Customer>(c => c.Customer)
            .WithMany(o => o.Orders)
            .HasForeignKey(c => c.CustomerId);
    }*/
   
}

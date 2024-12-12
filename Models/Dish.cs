using System.ComponentModel.DataAnnotations;

namespace LokaverkefniRestaurant.Models;

public class Dish 
{
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; }
    public int Price { get; set; } 
    public int Quantity { get; set; } 
    //public List<Cart> Carts { get; set; } = new List<Cart>();
}
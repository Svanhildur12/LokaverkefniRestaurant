using System.ComponentModel.DataAnnotations;

namespace LokaverkefniRestaurant.Models;

public class Customer
{
    
    public int Id { get; set; }
    public string CustomerEmail { get; set; }
    
    public List<Order> Orders { get; set; } =  new List<Order>();
}
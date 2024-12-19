using System.ComponentModel.DataAnnotations;

namespace LokaverkefniRestaurant.Models;

public class Customer
{
    [Key]   
    public int Id { get; set; }
    public string Email { get; set; }
  
    public List<Order> Orders { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace LokaverkefniRestaurant.Models.DTOs;

public class DrinkDTO
{
    [Key]
    public string strDrink { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    
}
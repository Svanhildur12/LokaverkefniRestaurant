using System.ComponentModel.DataAnnotations;

namespace LokaverkefniRestaurant.Models.DTOs;

public class DishDTO
{
    [Key]
    public string strMeal { get; set; }
    public int Price { get; set; } 
    public int Quantity { get; set; } 
   
}
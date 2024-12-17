using System.ComponentModel.DataAnnotations;

namespace LokaverkefniRestaurant.Models.DTOs;

public class DrinkDTO
{
    [Key]
    public string idDrink { get; set; }
    public string strDrink { get; set; }
    public string strDrinkThumb { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    
}
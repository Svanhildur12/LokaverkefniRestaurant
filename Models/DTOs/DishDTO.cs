using System.ComponentModel.DataAnnotations;

namespace LokaverkefniRestaurant.Models.DTOs;

public class DishDTO
{
    [Key]
    public string idMeal { get; set; }
    public string strMeal { get; set; }
    public string strMealThumb { get; set; }
    public string strInstructions { get; set; }
    public string strCategory { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
   
}
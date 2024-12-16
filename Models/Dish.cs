using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LokaverkefniRestaurant.Models;

public class Dish 
{
    [Key]
    public int id { get; set; }
    public string idMeal { get; set; }
    public string strMeal { get; set; }
    public string strMealThumb { get; set; }
    public string strInstructions { get; set; }
    public string strCategory { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
   
}
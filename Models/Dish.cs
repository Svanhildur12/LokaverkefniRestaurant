using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LokaverkefniRestaurant.Models;

public class Dish 
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("idMeal")]
    public string IdMeal { get; set; }
    public string strMeal { get; set; }
    public string strMealThumb { get; set; }
    public string strInstructions { get; set; }
    public string strCategory { get; set; }
    [JsonPropertyName("price")]
    public int Price { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
    
}
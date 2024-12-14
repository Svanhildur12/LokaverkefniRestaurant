using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LokaverkefniRestaurant.Models;

public class Drink 
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("idDrink")]
    public string idDrink { get; set; }
    public string strDrink { get; set; }
    public string strDrinkThumb { get; set; }
    public string strInstructions { get; set; }
    public string strCategory { get; set; }
    [JsonPropertyName("price")]
    public int Price { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
    
} 
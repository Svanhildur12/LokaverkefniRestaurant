using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LokaverkefniRestaurant.Models;

public class Order
{
    public int Id { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("guests")]
    public int Guests  { get; set; }
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    [JsonPropertyName("time")]
    public string Time { get; set; }
    
    [JsonPropertyName("dishes")]   
    public List<Dish> Dishes { get; set; } = new List<Dish>();
    [JsonPropertyName("drinks")]
    public List<Drink> Drinks { get; set; } = new List<Drink>();
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}
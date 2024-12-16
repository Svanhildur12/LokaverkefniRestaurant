using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LokaverkefniRestaurant.Models;

public class Drink 
{
    [Key]
    public int id { get; set; }
    public string idDrink { get; set; }
    public string strDrink { get; set; }
    public string strDrinkThumb { get; set; }
    public string strInstructions { get; set; }
    public string strCategory { get; set; }

    public int price { get; set; }

    public int quantity { get; set; }

    
} 
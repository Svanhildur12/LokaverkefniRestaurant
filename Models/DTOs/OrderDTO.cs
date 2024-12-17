namespace LokaverkefniRestaurant.Models.DTOs;

public class OrderDTO 
{
    public int OrderId { get; set; }
    public string Email { get; set; }
    public int Guests  { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public int Total { get; set; }
    
    public List<DishDTO> Dishes { get; set; } = new List<DishDTO>();
    public List<DrinkDTO> Drinks { get; set; } = new List<DrinkDTO>();
    
}


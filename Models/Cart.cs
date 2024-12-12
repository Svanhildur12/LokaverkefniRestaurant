namespace LokaverkefniRestaurant.Models;

public class Cart
{
    public int CartId { get; set; }
    public int CustomerId { get; set; }
    public Dish Dish { get; set; } = new Dish();
    public Drink Drink { get; set; } = new Drink();
    public decimal TotalPrice { get; set; }
    
}
namespace LokaverkefniRestaurant.Models;

public class Order
{
    public int Id { get; set; }
    public string Email { get; set; }
    public int Guests  { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public int CartId { get; set; } 
    public decimal Total { get; set; }
}
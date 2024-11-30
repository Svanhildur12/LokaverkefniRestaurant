namespace LokaverkefniRestaurant.Models;

public class Order
{
    public int Id { get; set; }
    //public DateOnly OrderDate { get; set; }
    //public TimeOnly OrderTime { get; set; }
    public int Guest  { get; set; }
    public int TotalPrice { get; set; }
    public int CustomerId { get; set; }
    
    //public List<Consumables> Consumables { get; set; } = new List<Consumables>();
   
}
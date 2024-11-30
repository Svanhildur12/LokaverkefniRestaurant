namespace LokaverkefniRestaurant.Models.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    //public DateOnly OrderDate { get; set; }
    //public TimeOnly OrderTime { get; set; }
    public int Guest  { get; set; }
    public int TotalPrice { get; set; }
}
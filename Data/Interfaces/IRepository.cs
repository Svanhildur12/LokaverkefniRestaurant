using LokaverkefniRestaurant.Models;

namespace LokaverkefniRestaurant.Data.Interfaces;

public interface IRepository
{
    Task<List<Order>> GetOrdersAsync();
    Task <Order> GetOrdersByIdAsync(int id);
    Task CreateOrderAsync(Order order);
    Task <Order> UpdateOrdersAsync(int id, Order order);
    Task<bool> DeleteOrdersAsync(int id);
    Task<List<Consumables>> GetConsumablesAsync();
    Task <Consumables> GetConsumablesByIdAsync(int id);
    Task <Consumables> CreateConsumablesAsync(Consumables consumables);
    Task<Consumables> UpdateConsumablesAsync(int id, Consumables consumables);
    Task <bool> DeleteConsumablesAsync(int id);
    Task <List<Customer>> GetCustomerAsync();
    Task <Customer> GetCustomerByIdAsync(int id);
    Task  <Customer> CreateCustomerAsync(Customer customer);
    Task <Customer> UpdateCustomerAsync(int id, Customer customer);
    Task <bool> DeleteCustomerAsync(int id);
 
}
using LokaverkefniRestaurant.Models;
using LokaverkefniRestaurant.Models.DTOs;

namespace LokaverkefniRestaurant.Data.Interfaces;

public interface IRepository
{
    Task<List<Order>> GetOrdersAsync();
    Task<Order> GetOrdersByIdAsync(int id);
    Task<Order> CreateOrderAsync(Order order);
    Task<Order> UpdateOrdersAsync(int id, Order order);
    Task<bool> DeleteOrdersAsync(int id);
    Task<List<Dish>> GetDishAsync();
    Task<Dish> GetDishByIdAsync(int id);
    Task<Dish> CreateDishAsync(Dish dish);
    Task<Dish> UpdateDishAsync(int id, Dish dish);
    Task<bool> DeleteDishAsync(int id);
    Task<List<Drink>> GetDrinkAsync();
    Task<Drink> CreateDrinkAsync(Drink drink);
    Task<Drink> UpdateDrinkAsync(int id,Drink drink);
    Task<bool> DeleteDrinkAsync(int id);
    Task<Drink> GetDrinkByIdAsync(int id);
    Task<List<Customer>> GetCustomerAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(int id, Customer customer);
    Task<bool> DeleteCustomerAsync(int id);
}
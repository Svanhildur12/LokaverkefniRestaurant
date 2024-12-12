using LokaverkefniRestaurant.Data.Interfaces;
using LokaverkefniRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LokaverkefniRestaurant.Data.Repository;

public class RestaurantRepository : IRepository
{
    private readonly RestaurantContext _dbContext = new();
    private IRepository _repository;

    public Task<List<Order>> GetOrdersAsync()
    {
        using (var db = _dbContext)
        {
            return db.Orders.ToListAsync();
        }
    }

    public async Task<Order> GetOrdersByIdAsync(int id)
    {
        Order order;
        using (var db = _dbContext)
        {
            order = await db.Orders.FirstOrDefaultAsync(x => x.Id == id)!;
        }

        return order;
    }

    public async Task CreateOrderAsync(Order order)
    {
        using (var db = _dbContext)
        {
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
        }
    }

    public async Task<Order> UpdateOrdersAsync(int id, Order order)
    {
        Order orderToUpdate;

        using (var db = _dbContext)
        {
            orderToUpdate = await db.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (orderToUpdate == null)
            {
                return null;
            }
            orderToUpdate.Guests = order.Guests;
            orderToUpdate.Email = order.Email;
            orderToUpdate.Date = order.Date;
            orderToUpdate.Time = order.Time;
            
            await db.SaveChangesAsync();
            return orderToUpdate;
        }
    }

    public async Task<bool> DeleteOrdersAsync(int id)
    {
        Order orderToDelete;

        using (var db = _dbContext)
        {
            orderToDelete = await db.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (orderToDelete == null)
            {
                return false;
            }
            else
            {
                db.Orders.Remove(orderToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }

    public Task<List<Dish>> GetDishAsync()
    {
        using (var db = _dbContext)
        {
            return db.Dishes.ToListAsync();
        }
    }

    public async Task<Dish> GetDishByIdAsync(int id)
    {
        Dish dish;
        using (var db = _dbContext)
        {
            dish = await db.Dishes.FirstOrDefaultAsync(x => x.Id == id);
        }
        return dish;
    }

    public async Task<Dish> CreateDishAsync(Dish dish)
    {
        using (var db = _dbContext)
        {
            await db.AddAsync(dish);
            await db.SaveChangesAsync();
        }
        return dish;
    }

    public async Task<Dish> UpdateDishAsync(int id,[FromBody] Dish dish)
    {
        Dish dishToUpdate;
        using (var db = _dbContext)
        {
            dishToUpdate = await db.Dishes.FirstOrDefaultAsync(x => x.Id == id);

            if (dishToUpdate == null)
            {
                return null;
            }
            
            dishToUpdate.Id = dishToUpdate.Id;
            dishToUpdate.Price = dishToUpdate.Price;
            dishToUpdate.Quantity = dishToUpdate.Quantity;
            dishToUpdate.Name = dishToUpdate.Name;
            
            await db.SaveChangesAsync();
            return dishToUpdate;
        }
    }

    public async Task<bool> DeleteDishAsync(int id)
    {
        Dish dishToDelete;

        using (var db = _dbContext)
        {
            dishToDelete = await db.Dishes.FirstOrDefaultAsync(x => x.Id  == id);

            if (dishToDelete == null)
            {
                return false;
            }
            else
            {
                db.Dishes.Remove(dishToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }

    public Task<List<Drink>> GetDrinkAsync()
    {
        using (var db = _dbContext)
        {
            return db.Drinks.ToListAsync();
        }
    }

    public async Task<Drink> CreateDrinkAsync(Drink drink)
    {
        using (var db = _dbContext)
        {
            await db.Drinks.AddAsync(drink);
            await db.SaveChangesAsync();
        }
        return drink;
    }

    public async Task<Drink> UpdateDrinkAsync(int id, Drink drink)
    {
        Drink drinkToUpdate;

        using (var db = _dbContext)
        {
            drinkToUpdate = await db.Drinks.FirstOrDefaultAsync(x => x.Id == id);

            if (drinkToUpdate == null)
            {
                return null;
            }
            drinkToUpdate.Id = drinkToUpdate.Id;
            drinkToUpdate.Price = drinkToUpdate.Price;
            drinkToUpdate.Quantity = drinkToUpdate.Quantity;
            drinkToUpdate.Name = drinkToUpdate.Name;
            
            await db.SaveChangesAsync();
            return drinkToUpdate;
        }
    }

    public async Task<bool> DeleteDrinkAsync(int id)
    {
        Drink drinkToDelete;

        using (var db = _dbContext)
        {
            drinkToDelete = await db.Drinks.FirstOrDefaultAsync(x => x.Id == id);

            if (drinkToDelete == null)
            {
                return false;
            }
            else
            {
                db.Drinks.Remove(drinkToDelete);
                await db.SaveChangesAsync();
            }
            return true;
        }
    }

    public async Task<Drink> GetDrinkByIdAsync(int id)
    {
        Drink drinks;
        using (var db = _dbContext)
        {
            drinks = await db.Drinks.FirstOrDefaultAsync(x => x.Id == id);
        }
        return drinks;
    }

    public Task<List<Customer>> GetCustomerAsync()
    {
        using (var db = _dbContext)
        {
           return db.Customers.ToListAsync();
        }
    }

    public async Task <Customer> GetCustomerByIdAsync(int id)
    {
        Customer customer;
        using (var db = _dbContext)
        {
            customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }
        return customer;
    }

    public async Task <Customer> CreateCustomerAsync(Customer customer)
    {
        using (var db = _dbContext)
        {
            await db.Customers.AddAsync(customer);
            await db.SaveChangesAsync();
        }
        return customer;
    }

    public async Task<Customer> UpdateCustomerAsync(int id,Customer customer)
    {
        Customer customerToUpdate;

        using (var db = _dbContext)
        {
            customerToUpdate = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customerToUpdate == null)
            {
                return null;
            }
            customerToUpdate.Email = customer.Email;
            
            await db.SaveChangesAsync();
            return customerToUpdate;
        }
    }

    public async Task <bool> DeleteCustomerAsync(int id)
    {
        Customer customerToDelete;
        using (var db = _dbContext)
        {
            customerToDelete = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customerToDelete == null)
            {
                return false;
            }
            else
            {
                db.Customers.Remove(customerToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }
        
    }

    public async Task<List<Cart>> GetCartAsync()
    {
        using (var db = _dbContext)
        {
            return await db.Carts.ToListAsync();
        }
    }

    public async Task<Cart> UpdateCartAsync(int id, Cart cart)
    {
        Cart cartToUpdate;

        using (var db = _dbContext)
        {
            cartToUpdate = await db.Carts.FirstOrDefaultAsync(x => x.CartId == id);
            if (cartToUpdate == null)
            {
                return null;
            }
            cartToUpdate.Dish = cart.Dish;
            cartToUpdate.Drink = cart.Drink;
            cartToUpdate.CustomerId = cart.CustomerId;
            cartToUpdate.TotalPrice = cart.TotalPrice;
            
            await db.SaveChangesAsync();
            return cartToUpdate;
        }
    }

    public async Task<bool> DeleteCartAsync(int id)
    {
        Cart cartToDelete;
        using (var db = _dbContext)
        {
            cartToDelete =  await db.Carts.FirstOrDefaultAsync(x => x.CartId == id);
            if (cartToDelete == null)
            {
                return false;
            }
            else
            {
                db.Carts.Remove(cartToDelete);
                await db.SaveChangesAsync();
            }
            return true;
        }
    }
}
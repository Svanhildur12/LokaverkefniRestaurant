using LokaverkefniRestaurant.Data.Interfaces;
using LokaverkefniRestaurant.Models;
using LokaverkefniRestaurant.Models.DTOs;
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
            return db.Orders.Include(o => o.Drinks).Include(o => o.Dishes).ToListAsync();
        }
    }

    public async Task<Order> GetOrdersByIdAsync(int id)
    {
        Order order;
        using (var db = _dbContext)
        {
            order = await db.Orders.Include(o => o.Dishes).Include(o => o.Drinks).FirstOrDefaultAsync(x => x.Id == id)!;
        }

        return order;
    }

    public async Task<Order> GetOrdersByEmailAsync(string email)
    {
        return await _dbContext.Orders.
            Include(o => o.Drinks)
            .Include(o => o.Dishes)
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == order.CustomerId);
        if (customer == null)
        {
            throw new ArgumentException("Customer with the specified ID does not exist.");
        }
        
        order.Customer = customer;
        
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public async Task<Order> UpdateOrdersAsync(int id, Order order)
    {
        Order orderToUpdate;

        using (var db = _dbContext)
        {
            orderToUpdate = await db.Orders.Include(o => o.Dishes).Include(o => o.Drinks).FirstOrDefaultAsync(x => x.Id == id);

            if (orderToUpdate == null)
            {
                return null;
            }
            orderToUpdate.Guests = order.Guests;
            orderToUpdate.Email = order.Email;
            orderToUpdate.Date = order.Date;
            orderToUpdate.Time = order.Time;
            orderToUpdate.Dishes = order.Dishes;
            orderToUpdate.Drinks = order.Drinks;
            
            await db.SaveChangesAsync();
            return orderToUpdate;
        }
    }

    public async Task<bool> DeleteOrdersAsync(int id)
    {
        Order orderToDelete;

        using (var db = _dbContext)
        {
            orderToDelete = await db.Orders.Include(o => o.Dishes).Include(o => o.Drinks).FirstOrDefaultAsync(x => x.Id == id);

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
            dish = await db.Dishes.FirstOrDefaultAsync(x => x.id == id);
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
            dishToUpdate = await db.Dishes.FirstOrDefaultAsync(x => x.id == id);

            if (dishToUpdate == null)
            {
                return null;
            }
            dishToUpdate.strMealThumb = dish.strMealThumb;
            dishToUpdate.strInstructions = dish.strInstructions;
            dishToUpdate.strCategory = dish.strCategory;
            dishToUpdate.price = dish.price;
            dishToUpdate.quantity = dish.quantity;
            dishToUpdate.strMeal = dish.strMeal;
            dishToUpdate.idMeal = dish.idMeal;
            
            
            await db.SaveChangesAsync();
            return dishToUpdate;
        }
    }

    public async Task<bool> DeleteDishAsync(int id)
    {
        Dish dishToDelete;

        using (var db = _dbContext)
        {
            dishToDelete = await db.Dishes.FirstOrDefaultAsync(x => x.id  == id);

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
            drinkToUpdate = await db.Drinks.FirstOrDefaultAsync(x => x.strDrink == drink.strDrink);

            if (drinkToUpdate == null)
            {
                return null;
            }
            drinkToUpdate.price = drink.price;
            drinkToUpdate.quantity = drink.quantity;
            drinkToUpdate.strDrink = drink.strDrink;
            drinkToUpdate.strCategory = drink.strCategory;
            drinkToUpdate.idDrink = drink.idDrink;
            drinkToUpdate.strInstructions = drink.strInstructions;
            drinkToUpdate.strDrinkThumb = drink.strDrinkThumb;
            
            await db.SaveChangesAsync();
            return drinkToUpdate;
        }
    }

    public async Task<bool> DeleteDrinkAsync(int id)
    {
        Drink drinkToDelete;

        using (var db = _dbContext)
        {
            drinkToDelete = await db.Drinks.FirstOrDefaultAsync(x => x.id == id);

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
            drinks = await db.Drinks.FirstOrDefaultAsync(x => x.id == id);
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
        return await _dbContext.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task <Customer> CreateCustomerAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
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
        var customerToDelete = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
        if (customerToDelete == null)
        {
            return false;
        }
        _dbContext.Customers.Remove(customerToDelete);
        await _dbContext.SaveChangesAsync();
        return true;
        
    }

    public async Task<Customer> GetCustomerByEmailAsync(string email)
    {
            return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }
}
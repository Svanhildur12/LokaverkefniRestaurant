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
            orderToUpdate.Guest = order.Guest;
            orderToUpdate.TotalPrice = order.TotalPrice;
            
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

    public Task<List<Consumables>> GetConsumablesAsync()
    {
        using (var db = _dbContext)
        {
            return db.Consumables.ToListAsync();
        }
    }

    public async Task<Consumables> GetConsumablesByIdAsync(int id)
    {
        Consumables consumable;
        using (var db = _dbContext)
        {
            consumable = await db.Consumables.FirstOrDefaultAsync(x => x.Id == id);
        }

        return consumable;
    }

    public async Task<Consumables> CreateConsumablesAsync(Consumables consumables)
    {
        using (var db = _dbContext)
        {
            await db.Consumables.AddAsync(consumables);
            await db.SaveChangesAsync();
            return consumables;
        }
    }

    public async Task<Consumables> UpdateConsumablesAsync(int id, Consumables consumables)
    {
        Consumables consumablesToUpdate;

        using (var db = _dbContext)
        {
            consumablesToUpdate = await db.Consumables.FirstOrDefaultAsync(x => x.Id == id);

            if (consumablesToUpdate == null)
            {
                return null;
            }
            consumablesToUpdate.Dishes = consumables.Dishes;
            consumablesToUpdate.Drinks = consumables.Drinks;
            
            await db.SaveChangesAsync();
            return consumablesToUpdate;
        }
    }

    public async Task <bool> DeleteConsumablesAsync(int id)
    {
        Consumables consumablesToDelete;
        using (var db = _dbContext)
        {
           consumablesToDelete = await db.Consumables.FirstOrDefaultAsync(x => x.Id == id);
           if (consumablesToDelete == null)
           {
               return false;
           }
           else
           {
               db.Consumables.Remove(consumablesToDelete);
               await db.SaveChangesAsync();
               return true;
           }
        }
        
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
}
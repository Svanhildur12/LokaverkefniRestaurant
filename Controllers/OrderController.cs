using System.ComponentModel.DataAnnotations;
using LokaverkefniRestaurant.Data.Interfaces;
using LokaverkefniRestaurant.Models;
using LokaverkefniRestaurant.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LokaverkefniRestaurant.Controllers;


[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IRepository _repository;
    
    public OrderController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetOrders()
    {
        try
        {
            List<Order> orders = await _repository.GetOrdersAsync();
            return Ok(orders);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Order>> GetOrdersById(int id)
    {
        try
        {
            Order orders = await _repository.GetOrdersByIdAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orders);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpGet]
    [Route("byEmail/{email}")]
    public async Task<ActionResult<Order>> GetOrderByEmail(string email)
    {
        try
        {
            Order order = await _repository.GetOrdersByEmailAsync(email);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order)
    {
        try
        {
            Console.WriteLine($"Received Order: CustomerId={order.CustomerId}, Email={order.Email}");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(new { errors });
            }

            var createdOrder = await _repository.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrdersById), new { id = createdOrder.Id }, createdOrder);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Order>> UpdateOrdersAsync(int id,[FromBody] Order order)
    {
        try
        {
            Order orders = await _repository.UpdateOrdersAsync(id, order);
            if (orders == null)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction(nameof(GetOrdersById), new { id = orders.Id }, orders);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Order>> DeleteOrderAsync(int id)
    {
        try
        {
            bool deleteSuccess = await _repository.DeleteOrdersAsync(id);
            if (!deleteSuccess)
            {
                return NotFound();
            }
            else
            {
                return Ok(new {Message = "Order deleted"});
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
        
    }
}
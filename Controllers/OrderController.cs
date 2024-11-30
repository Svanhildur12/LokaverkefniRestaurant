using LokaverkefniRestaurant.Data.Interfaces;
using LokaverkefniRestaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace LokaverkefniRestaurant.Controllers;


[Route("api/orders")]
[Controller]
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
    
    [HttpPost]
    public async Task<ActionResult> CreateOrder([FromBody] Order order)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateOrderAsync(order);
                return CreatedAtAction(nameof(GetOrdersById), new { id = order.Id }, order);
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500);
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
                return NoContent();
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
        
    }
}
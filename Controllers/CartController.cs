using LokaverkefniRestaurant.Data.Interfaces;
using LokaverkefniRestaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace LokaverkefniRestaurant.Controllers;

[Route("api/cart")]
[Controller]

public class CartController : ControllerBase
{
    private readonly IRepository _repository;

    public CartController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cart>>> GetCartAsync()
    {
        try
        {
            List<Cart> carts = await _repository.GetCartAsync();
            return Ok(carts);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
       
    }
    
    [HttpPost]
    public async Task<ActionResult<Cart>> AddToCartAsync()
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.GetCartAsync();
                return Ok();
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

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Cart>> UpdateCartAsync(int id, [FromBody] Cart cart)
    {
        try
        {
            Cart carts = await _repository.UpdateCartAsync(id, cart);
            if (carts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(carts);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Cart>> DeleteCartAsync(int id)
    {
            try
            {
                bool deleteSuccess = await _repository.DeleteCartAsync(id);
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
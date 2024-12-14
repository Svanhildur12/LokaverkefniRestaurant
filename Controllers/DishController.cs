using LokaverkefniRestaurant.Data.Interfaces;
using LokaverkefniRestaurant.Models;
using LokaverkefniRestaurant.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LokaverkefniRestaurant.Controllers;

[Route("api/dish")]
[Controller]
public class DishController : ControllerBase
{
    private readonly IRepository _repository;

    public DishController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Dish>>> GetDishAsync()
    {
        try
        {
            List<Dish> dishes = await _repository.GetDishAsync();
            return Ok(dishes);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Dish>> GetDishById(int id)
    {
        try
        {
            Dish dish = await _repository.GetDishByIdAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dish);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Dish>> CreateDish([FromBody] Dish dish)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateDishAsync(dish);
                return CreatedAtAction(nameof(GetDishById), new { id = dish.Id }, dish);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Dish>> UpdateDishAsync(int id, [FromBody] Dish dish)
    {
        try
        {
            Dish updatedDish = await _repository.UpdateDishAsync(id, dish);
            if (updatedDish == null)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction(nameof(GetDishById), new { id = updatedDish.Id }, updatedDish);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Dish>> DeleteDishAsync(int id)
    {
        try
        {
            bool deleteSuccess = await _repository.DeleteDishAsync(id);
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


using LokaverkefniRestaurant.Data.Interfaces;
using LokaverkefniRestaurant.Models;
using LokaverkefniRestaurant.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LokaverkefniRestaurant.Controllers;

[Route("api/drinks")]
[Controller]

public class DrinkController : ControllerBase
{
    private readonly IRepository _repository;

    public DrinkController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Drink>>> GetDrinkAsync()
    {
        try
        {
            List<Drink> drinks = await _repository.GetDrinkAsync();
            return Ok(drinks);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Drink>> GetDrinkById(int id)
    {
        try
        {
            Drink drinks = await _repository.GetDrinkByIdAsync(id);
            if (drinks == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(drinks);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Drink>> CreateDrink([FromBody] Drink drink)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateDrinkAsync(drink);
                return CreatedAtAction(nameof(GetDrinkById), new { id = drink.idDrink }, drink);
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
            public async Task<ActionResult<Drink>> UpdateDrinkAsync(int id,[FromBody] Drink drink)
            {
                try
                {
                    Drink updatedDrinks = await _repository.UpdateDrinkAsync(id,drink);
                    if (updatedDrinks == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return CreatedAtAction(nameof(GetDrinkById), new { id = updatedDrinks.id }, updatedDrinks);
                    }
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            [HttpDelete]
            [Route("{id}")]
            public async Task<ActionResult<Drink>> DeleteDrinkAsync(int id)
            {
                try
                {
                    bool deleteSuccess = await _repository.DeleteDrinkAsync(id);
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
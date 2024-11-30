using LokaverkefniRestaurant.Data.Interfaces;
using LokaverkefniRestaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace LokaverkefniRestaurant.Controllers;

[Route("api/consumables")]
[Controller]

public class ConsumablesController : ControllerBase
{
    private readonly IRepository _repository;
    
    public ConsumablesController(IRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<ActionResult<List<Consumables>>> GetConsumablesAsync()
    {
        try
        {
            List<Consumables> consumable = await _repository.GetConsumablesAsync();
            return Ok(consumable);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Consumables>> GetConsumablesById(int id)
    {
        try
        {
            Consumables consumable = await _repository.GetConsumablesByIdAsync(id);
            if (consumable == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(consumable);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPost]
    public async Task<ActionResult> CreateConsumablesAsync([FromBody]Consumables consumables)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateConsumablesAsync(consumables);
                return CreatedAtAction(nameof(GetConsumablesById), new { id = consumables.Id }, consumables);
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
    public async Task<ActionResult<Consumables>> UpdateConsumablesAsync(int id, [FromBody]Consumables consumables)
    {
        try
        {
            Consumables consumable = await _repository.UpdateConsumablesAsync(id, consumables);
            if (consumable == null)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction(nameof(GetConsumablesById), new { id = consumable.Id }, consumables);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Consumables>> DeleteConsumablesAsync(int id)
    {
        try
        {
            bool deleteSuccess = await _repository.DeleteConsumablesAsync(id);
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
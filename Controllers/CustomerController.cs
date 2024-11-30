using LokaverkefniRestaurant.Data.Interfaces;
using LokaverkefniRestaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace LokaverkefniRestaurant.Controllers;

[Route("api/customer")]
[Controller]
public class CustomerController : ControllerBase
{
    private readonly IRepository _repository; 
    public CustomerController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomer()
        {
            try
            {
                List<Customer> customers = await _repository.GetCustomerAsync();
                return Ok(customers);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            try
            {
                Customer customers = await _repository.GetCustomerByIdAsync(id);
                if (customers == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(customers);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateCustomerAsync(customer);
                    return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
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
        public async Task<ActionResult<Customer>> UpdateCustomerAsync(int id,[FromBody] Customer customer)
        {
            try
            {
                Customer customers = await _repository.UpdateCustomerAsync(id, customer);
                if (customers == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomerAsync(int id)
        {
            try
            {
                bool deleteSuccess = await _repository.DeleteCustomerAsync(id);
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
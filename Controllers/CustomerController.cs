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
        [HttpGet]
        [Route("{email}")]
        public async Task<ActionResult<Customer>> GetCustomerByEmail(string email)
        {
            try
            {
                Customer customers = await _repository.GetCustomerByEmailAsync(email);
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
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (string.IsNullOrEmpty(customer.Email))
                {
                    return BadRequest("Email is required.");
                }
                
                var existingCustomer = await _repository.GetCustomerByEmailAsync(customer.Email);
                if (existingCustomer != null)
                {
                    return Conflict("Customer with this email already exists.");
                }
                
                var newCustomer = await _repository.CreateCustomerAsync(customer);

                return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            try
            {
                Customer updatedCustomer = await _repository.UpdateCustomerAsync(id, customer);
                if (updatedCustomer == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetCustomerById), new { id = updatedCustomer.Id }, updatedCustomer);
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
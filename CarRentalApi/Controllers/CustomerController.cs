using CarRentalApi.DataAccess;
using CarRentalApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomerAsync();
            return Ok(customers);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(string id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            await _customerRepository.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, Customer updatedCustomer)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            await _customerRepository.UpdateCustomerAsync(id, updatedCustomer);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);
            if (existingCustomer == null)
            {
                return NoContent();
            }
            await _customerRepository.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}

using CarRentalApi.Models;
using CarRentalApi.Repositories;

namespace CarRentalApi.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }
        public async Task<Customer?> GetCustomerByIdAsync(string id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }
        public async Task CreateCustomerAsync(Customer customer)
        {
           await _customerRepository.CreateAsync(customer);
        }
        public async Task<bool> UpdateCustomerAsync(string id, Customer updatedCustomer)
        {
            var custumer = await _customerRepository.GetByIdAsync(id);
            if (custumer is null)
            {
                return false;
            }

            updatedCustomer.Id = id;
            await _customerRepository.UpdateAsync(id, updatedCustomer);
            return true;
        }
        public async Task<bool> DeleteCustomerAsync(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer is null) return false;

            await _customerRepository.DeleteAsync(id);
            return true;
        }
    }
}

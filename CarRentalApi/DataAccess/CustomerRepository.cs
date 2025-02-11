using CarRentalApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalApi.DataAccess
{
    public class CustomerRepository
    {
        private readonly IMongoCollection<Customer> _customerCollection;

        public CustomerRepository(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _customerCollection = database.GetCollection<Customer>("customers");
        }

        public async Task<List<Customer>> GetAllCustomerAsync() =>
            await _customerCollection.Find(_ => true).ToListAsync();

        public async Task<Customer?> GetCustomerByIdAsync(string id) =>
            await _customerCollection.Find(customer => customer.Id == id).FirstOrDefaultAsync();

        public async Task CreateCustomerAsync(Customer newCustomer) =>
            await _customerCollection.InsertOneAsync(newCustomer);

        public async Task UpdateCustomerAsync(string id, Customer updatedCustomer) =>
            await _customerCollection.ReplaceOneAsync(customer => customer.Id == id, updatedCustomer);

        public async Task DeleteCustomerAsync(string id) =>
            await _customerCollection.DeleteOneAsync(customer => customer.Id == id);
    }
}

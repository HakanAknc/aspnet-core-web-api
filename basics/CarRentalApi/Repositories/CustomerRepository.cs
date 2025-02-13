using CarRentalApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalApi.Repositories
{
    public class CustomerRepository
    {
        private readonly IMongoCollection<Customer> _customerCollection;

        public CustomerRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _customerCollection = mongoDatabase.GetCollection<Customer>("customers");
        }

        public async Task<List<Customer>> GetAllAsync() =>
            await _customerCollection.Find(_ =>  true).ToListAsync();

        public async Task<Customer> GetByIdAsync(string id) =>
            await _customerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Customer customer) =>
            await _customerCollection.InsertOneAsync(customer);

        public async Task UpdateAsync(string id, Customer updatedCustomer) =>
            await _customerCollection.ReplaceOneAsync(x => x.Id == id, updatedCustomer);

        public async Task DeleteAsync(string id) =>
            await _customerCollection.DeleteOneAsync(x => x.Id == id);
    }
}

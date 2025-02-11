using CarRentalApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalApi.DataAccess
{
    public class PricingRepository
    {
        private readonly IMongoCollection<Pricing> _pricingCollection;

        public PricingRepository(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _pricingCollection = database.GetCollection<Pricing>("pricings");
        }

        public async Task<List<Pricing>> GetAllPricingAsync() =>
            await _pricingCollection.Find(_ => true).ToListAsync();

        public async Task<Pricing?> GetPricingByIdAsync(string id) =>
            await _pricingCollection.Find(pricing => pricing.Id == id).FirstOrDefaultAsync();

        public async Task CreatePricingAsync(Pricing pricing) =>
            await _pricingCollection.InsertOneAsync(pricing);

        public async Task UpdatePricingAsync(string id, Pricing updatedPricing) =>
            await _pricingCollection.ReplaceOneAsync(pricing => pricing.Id == id, updatedPricing);

        public async Task DeletePricingAsync(string id) =>
            await _pricingCollection.DeleteOneAsync(pricing => pricing.Id == id);
    }
}

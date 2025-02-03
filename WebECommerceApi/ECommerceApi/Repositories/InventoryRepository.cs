using ECommerceApi.Models;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class InventoryRepository
    {
        private readonly IMongoCollection<Inventory> _inventoryCollection;

        public InventoryRepository(IMongoDatabase database)
        {
            _inventoryCollection = database.GetCollection<Inventory>("Inventory");
        }

        public async Task<List<Inventory>> GetAllInventoryAsync()
        {
            return await _inventoryCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Inventory> GetInventoryByProductIdAsync(string productId)
        {
            return await _inventoryCollection.Find(i => i.ProductId == productId).FirstOrDefaultAsync();
        }

        public async Task UpdateStockAsync(string productId, int quantity)
        {
            var update = Builders<Inventory>.Update.Set(i => i.Quantity, quantity);
            await _inventoryCollection.UpdateOneAsync(i => i.ProductId == productId, update, new UpdateOptions { IsUpsert = true });
        }
    }
}

using ECommerceApi.Models;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class OrderRepository
    {
        private readonly IMongoCollection<Order> _ordersCollection;

        public OrderRepository(IMongoDatabase database)
        {
            _ordersCollection = database.GetCollection<Order>("Orders");
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _ordersCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(string id)
        {
            return await _ordersCollection.Find(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _ordersCollection.InsertOneAsync(order);
        }

        public async Task UpdateOrderAsync(string id, Order updatedOrder)
        {
            await _ordersCollection.ReplaceOneAsync(o => o.Id == id, updatedOrder);
        }

        public async Task DeleteOrderAsync(string id)
        {
            await _ordersCollection.DeleteOneAsync(o => o.Id == id);
        }
    }
}

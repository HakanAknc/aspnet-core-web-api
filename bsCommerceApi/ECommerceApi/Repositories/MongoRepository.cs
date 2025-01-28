using MongoDB.Driver;
using MongoDB.Bson;
using ECommerceApi.Models;

namespace ECommerceApi.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetByIdAsync(string id) =>
            await _collection.Find(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id))).FirstOrDefaultAsync();

        public async Task CreateAsync(T entity) => await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, T entity) =>
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id)), entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", ObjectId.Parse(id)));
    }
}

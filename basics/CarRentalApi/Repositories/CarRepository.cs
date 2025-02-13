using CarRentalApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalApi.Repositories
{
    public class CarRepository
    {
        private readonly IMongoCollection<Car> _carsCollection;

        public CarRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _carsCollection = mongoDatabase.GetCollection<Car>("cars");
        }

        public async Task<List<Car>> GetAllAsync() =>
            await _carsCollection.Find(_ => true).ToListAsync();

        public async Task<Car> GetByIdAsync(string id) =>
            await _carsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Car car) =>
            await _carsCollection.InsertOneAsync(car);

        public async Task UpdateAsync(string id, Car updatedCar) =>
            await _carsCollection.ReplaceOneAsync(x => x.Id == id, updatedCar);

        public async Task DeleteAsync(string id) =>
            await _carsCollection.DeleteOneAsync(x => x.Id == id);
    }
}

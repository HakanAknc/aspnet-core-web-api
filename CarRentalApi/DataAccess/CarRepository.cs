using CarRentalApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarRentalApi.DataAccess
{
    public class CarRepository
    {
        private readonly IMongoCollection<Car> _carsCollection;

        public CarRepository(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _carsCollection = database.GetCollection<Car>("cars");   // Burada collection bağlantısı yapılıp "isim" verilmiş.
        }

        public async Task<List<Car>> GetAllCarsAsync() =>
            await _carsCollection.Find(_ => true).ToListAsync();

        public async Task<Car?> GetCarByIdAsync(string id) =>
            await _carsCollection.Find(car => car.Id == id).FirstOrDefaultAsync();

        public async Task CreateCarAsync(Car newCar) =>
            await _carsCollection.InsertOneAsync(newCar);

        public async Task UpdateCarAsync(string id, Car updatedCar) =>
            await _carsCollection.ReplaceOneAsync(car => car.Id == id, updatedCar);

        public async Task DeleteCarAsync(string id) =>
            await _carsCollection.DeleteOneAsync(car => car.Id == id);
    }
}

using CarRentalWeb.Models;
using CarRentalWeb.Repositories;

namespace CarRentalWeb.Services
{
    public class CarService : ICarService
    {
        public readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<Car>> GetAllCarsAsync() =>
            await _carRepository.GetAllCarsAsync();

        public async Task<Car> GetCarByIdAsync(string id) =>
            await _carRepository.GetCarByIdAsync(id);

        public async Task CreateCarAsync(Car car) =>
            await _carRepository.CreateCarAsync(car);

        public async Task UpdateCarAsync(string id, Car updatedCar) =>
            await _carRepository.UpdateCarAsync(id, updatedCar);

        public async Task DeleteCarAsync(string id) =>
            await _carRepository.DeleteCarAsync(id);
    }
}

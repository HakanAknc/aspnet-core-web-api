using CarProject.Models;
using CarProject.Repositories;

namespace CarProject.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<Car>> GetAllCarsAsync() =>
            await _carRepository.GetAllCarsAsync();

        public async Task<Car> GetCarByIdAsync(string id) =>
            await _carRepository.GetCarByIdAsync(id);

        public async Task CreateCarAsync(Car car)
        {
            car.CreateTime = DateTime.UtcNow;
            car.ModifyTime = DateTime.UtcNow;
            car.IsActive = false;
            await _carRepository.CreateCarAsync(car);
        }

        public async Task UpdateCarAsync(string id, Car updatedCar)
        {
            updatedCar.ModifyTime = DateTime.UtcNow;
            await _carRepository.UpdateCarAsync(id, updatedCar);
        }

        public async Task DeleteCarAsync(string id) =>
            await _carRepository.DeleteCarAsync(id);
    }
}

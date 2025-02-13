using CarRentalApi.Models;
using CarRentalApi.Repositories;

namespace CarRentalApi.Services
{
    public class CarService
    {
        private readonly CarRepository _carRepository;

        public CarService(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _carRepository.GetAllAsync();
        }

        public async Task<Car> GetCarByIdAsync(string id)
        {
            return await _carRepository.GetByIdAsync(id);
        }

        public async Task CreateCarAsync(Car car)
        {
            await _carRepository.CreateAsync(car);
        }

        public async Task<bool> UpdateCarAsync(string id, Car updatedCar)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car is null)
            {
                return false;
            }
            updatedCar.Id = id;
            await _carRepository.UpdateAsync(id, updatedCar);
            return true;
        }

        public async Task<bool> DeleteCarAsync(string id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car is null) return false;

            await _carRepository.DeleteAsync(id);
            return true;
        }
    }
}

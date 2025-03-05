using CarRentalWeb.Models;

namespace CarRentalWeb.Services
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(string id);
        Task CreateCarAsync(Car car);
        Task UpdateCarAsync(string id, Car updatedCar);
        Task DeleteCarAsync(string id);
    }
}

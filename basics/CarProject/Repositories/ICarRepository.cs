using CarProject.Models;

namespace CarProject.Repositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(string id);
        Task CreateCarAsync(Car car);
        Task UpdateCarAsync(string id, Car updatedCar);
        Task DeleteCarAsync(string id);
    }
}

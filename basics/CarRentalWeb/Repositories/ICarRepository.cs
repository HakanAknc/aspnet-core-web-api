﻿using CarRentalWeb.Models;

namespace CarRentalWeb.Repositories
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

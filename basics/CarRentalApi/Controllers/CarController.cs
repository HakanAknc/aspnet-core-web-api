using CarRentalApi.DTOs;
using CarRentalApi.Models;
using CarRentalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _carService.GetAllCarsAsync();
            var carDTOs = cars.Select(car => new GetCarDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                DailyPrice = car.DailyPrice
            }).ToList();
            return Ok(carDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var carDto = new GetCarDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                DailyPrice = car.DailyPrice
            };
            return Ok(carDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDto createCarDto)
        {
            var car = new Car
            {
                Brand = createCarDto.Brand,
                Model = createCarDto.Model,
                Year = createCarDto.Year,
                DailyPrice = createCarDto.DailyPrice
            };

            await _carService.CreateCarAsync(car);
            var carDto = new GetCarDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                DailyPrice = car.DailyPrice
            };
            return CreatedAtAction(nameof(GetById), new { id = car.Id }, carDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateCarDto updateCarDto)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null) return NotFound();

            car.Brand = updateCarDto.Brand;
            car.Model = updateCarDto.Model;
            car.Year = updateCarDto.Year;
            car.DailyPrice = updateCarDto.DailyPrice;

            await _carService.UpdateCarAsync(id, car);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null) return NotFound();

            await _carService.DeleteCarAsync(id);
            return NoContent();
        }
    }
}

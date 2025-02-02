using CarMarketplace.Data;
using CarMarketplace.Helpers;
using CarMarketplace.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMarketplace.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCars(CarQueryObject carQuery)
        {
            var cars = _context.Cars.Include(c => c.Store).AsQueryable();
            if (!string.IsNullOrWhiteSpace(carQuery.Model))
            {
                cars = cars.Where(s => s.Model.Contains(carQuery.Model));
            }
            if (!string.IsNullOrWhiteSpace(carQuery.SortBy))
            {
                if (carQuery.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    cars = carQuery.IsDescending ? cars.OrderByDescending(s => s.Price) : cars.OrderBy(s => s.Price);

                }
            }
            return await cars.ToListAsync();
        }
        public async Task<Car?> GetCarById(int carId)
        {
            return await _context.Cars.FindAsync(carId);
        }

        public async Task AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }
        public async Task<Car?> UpdateCar(int id, Car carModel)
        {
            var ExistingCar = await _context.Cars.FindAsync(id);
            if (ExistingCar == null) 
            {
                return null;
            }
            ExistingCar.Id = id;
            ExistingCar.Make = carModel.Make;
            ExistingCar.Model = carModel.Model;
            ExistingCar.Odometer = carModel.Odometer;
            ExistingCar.Price = carModel.Price;
            _context.Cars.Update(ExistingCar);
            await _context.SaveChangesAsync();
            return ExistingCar;
        }

        public async Task DeleteCar(int carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

    }
}

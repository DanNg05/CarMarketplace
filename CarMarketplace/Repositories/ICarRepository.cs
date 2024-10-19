using CarMarketplace.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarMarketplace.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car?> GetCarById(int carId);
        Task AddCar(Car car);
        Task<Car?> UpdateCar(int id, Car car);
        Task DeleteCar(int carId);
    }
}

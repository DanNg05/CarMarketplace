using CarMarketplace.DTOs.Car;
using CarMarketplace.Mappers;
using CarMarketplace.Models;
using CarMarketplace.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarMarketplace.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IStoreRepository _storeRepository;
        public CarsController(ICarRepository carRepository, IStoreRepository storeRepository)
        {
            _carRepository = carRepository;
            _storeRepository = storeRepository;
        }


        // GET: api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cars = await _carRepository.GetAllCars();
            var carDtos = cars.Select(CarMappers.ToCarDto).ToList();
            return Ok(carDtos);
        }

        // GET: api/car/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCar(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var car = await _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(CarMappers.ToCarDto(car));
        }

        // POST: api/car
        [HttpPost]
        public async Task<ActionResult<CarDto>> PostCar( int storeId, CreateCarDto createCarDto)
        {
            //if (carDto == null)
            //{
            //    return BadRequest("Car data cannot be null.");
            //}

            //var car = carDto.ToCar();

            //if (car == null)
            //{
            //    return BadRequest("Failed to map CarDto to Car.");
            //}

            //await _carRepository.AddCar(car);

            //return CreatedAtAction("GetCar", new { id = car.Id }, car.ToCarDto());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _storeRepository.StoreExists(storeId))
            {
                return BadRequest("Store does not exist here");
            }
            var car = CarMappers.ToCarFromCreate(createCarDto, storeId);
            await _carRepository.AddCar(car);
            return CreatedAtAction("GetCar", new { id = car.Id }, car.ToCarDto());
        }

        // PUT: api/car/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, UpdateCarDto updateCarDto)
        {
            //if (carDto == null)
            //{
            //    return BadRequest("Car data cannot be null.");
            //}

            //// Automatically assign the URL id to the carDto.Id
            //carDto.Id = id;

            //var car = carDto.ToCar();
            //if (car == null)
            //{
            //    return BadRequest("Car could not be mapped.");
            //}

            //await _carRepository.UpdateCar(car);

            //return NoContent();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (updateCarDto == null)
            {
                return BadRequest("Car data cannot be null");
            }
            var car = await _carRepository.UpdateCar(id, CarMappers.ToCarFromUpdate(updateCarDto));
            return Ok(car);
        }

        // DELETE: api/car/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _carRepository.DeleteCar(id);
            return NoContent();
        }
    }
}

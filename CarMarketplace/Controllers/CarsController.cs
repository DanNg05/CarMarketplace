using CarMarketplace.DTOs.Car;
using CarMarketplace.Helpers;
using CarMarketplace.Mappers;
using CarMarketplace.Models;
using CarMarketplace.Repositories;
using CarMarketplace.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarMarketplace.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ImageService _imageService;

        public CarsController(ICarRepository carRepository, IStoreRepository storeRepository, ImageService imageService)
        {
            _carRepository = carRepository;
            _storeRepository = storeRepository;
            _imageService = imageService;
        }


        // GET: api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars([FromQuery] CarQueryObject carQuery)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cars = await _carRepository.GetAllCars(carQuery);
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
        public async Task<ActionResult<CarDto>> PostCar( int storeId, [FromForm] CreateCarDto createCarDto, [FromForm] List<IFormFile> images)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _storeRepository.StoreExists(storeId))
            {
                return BadRequest("Store does not exist here");
            }
            //var car = CarMappers.ToCarFromCreate(createCarDto, storeId);
            //await _carRepository.AddCar(car);
            //return CreatedAtAction("GetCar", new { id = car.Id }, car.ToCarDto());
            List<string> imageUrls = new List<string>();
            if (images != null && images.Count > 0)
            {
                imageUrls = await _imageService.UploadImagesAsync(images);
            }

            var car = CarMappers.ToCarFromCreate(createCarDto, storeId);
            car.ImageUrls = imageUrls; // Assign the uploaded image URL

            await _carRepository.AddCar(car);
            return CreatedAtAction("GetCar", new { id = car.Id }, car.ToCarDto());
        }

        // PUT: api/car/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, [FromForm] UpdateCarDto updateCarDto, [FromForm] List<IFormFile>? images)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (updateCarDto == null)
            {
                return BadRequest("Car data cannot be null");
            }
            //var car = await _carRepository.UpdateCar(id, CarMappers.ToCarFromUpdate(updateCarDto));
            //return Ok(car);
            var existingCar = await _carRepository.GetCarById(id);
            if (existingCar == null)
            {
                return NotFound("Car not found");
            }
            List<string> imageUrls = existingCar.ImageUrls ?? new List<string>();

            if (images != null && images.Count > 0)
            {
                // Clear the old image URLs
                imageUrls.Clear();

                // Upload the new images and add their URLs to the list
                var newImageUrls = await _imageService.UploadImagesAsync(images);
                imageUrls.AddRange(newImageUrls);
            }

            // Update the car properties using the mapper
            CarMappers.ToCarFromUpdate(existingCar, updateCarDto);
            existingCar.ImageUrls = imageUrls; // Update the image URLs

            await _carRepository.UpdateCar(id, existingCar);
            return Ok(existingCar.ToCarDto());
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

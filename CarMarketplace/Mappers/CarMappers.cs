using CarMarketplace.DTOs.Car;
using CarMarketplace.DTOs.Store;
using CarMarketplace.Models;

namespace CarMarketplace.Mappers
{
    public static class CarMappers
    {
        //Convert Car Model to CarDto
        public static CarDto? ToCarDto(this Car car)
        {
            if (car == null) return null;

            return new CarDto
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Odometer = car.Odometer,
                Price = car.Price,
                StoreId = car.StoreId,
                ImageUrls = car.ImageUrls
            };
        }

        // Converts a CarDto back to a Car model
        public static Car? ToCar(this CarDto carDto)
        {
            if (carDto == null) return null;

            return new Car
            {
                Id = carDto.Id,
                Make = carDto.Make,
                Model = carDto.Model,
                Odometer = carDto.Odometer,
                Price = carDto.Price,
                StoreId = carDto.StoreId,
                ImageUrls = carDto.ImageUrls
            };
        }

        //Create Car (POST)
        public static Car ToCarFromCreate(CreateCarDto createCarDto, int storeId)
        {
            return new Car
            {
                Make = createCarDto.Make,
                Model = createCarDto.Model,
                Odometer = createCarDto.Odometer,
                Price = createCarDto.Price,
                StoreId = storeId,
                ImageUrls = createCarDto.ImageUrls
            };
        }

        //Update Car (PUT)
        public static void ToCarFromUpdate(Car car, UpdateCarDto updateCarDto)
        {

            car.Make = updateCarDto.Make;
            car.Model = updateCarDto.Model;
            car.Odometer = updateCarDto.Odometer;
            car.Price = updateCarDto.Price;
            car.ImageUrls = updateCarDto.ImageUrls;
         
        }
    }
}

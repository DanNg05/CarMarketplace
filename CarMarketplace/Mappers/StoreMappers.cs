using CarMarketplace.Models; 
using CarMarketplace.DTOs.Store;
using CarMarketplace.DTOs.Car;

namespace CarMarketplace.Mappers
{
    public static class StoreMappers
    {
        // Converts a Store model to a StoreDto
        public static StoreDto? ToStoreDto(this Store store)
        {
            if (store == null) return null;

            return new StoreDto
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address,
                PhoneNumber = store.PhoneNumber,
                ImageUrl = store.ImageUrl,
                Cars = store.Cars.Select(c => c.ToCarDto()).ToList()
            };
        }

        // Converts a StoreDto back to a Store model
        public static Store? ToStore(this StoreDto storeDto, string? imageUrl = null)
        {
            if (storeDto == null) return null;

            return new Store
            {
                Id = storeDto.Id,
                Name = storeDto.Name,
                Address = storeDto.Address,
                PhoneNumber = storeDto.PhoneNumber,
                ImageUrl = imageUrl ?? storeDto.ImageUrl
            };
        }

        //Create Store (Post)
        public static Store ToStoreFromCreate(this CreateStoreDto createStoreDto) 
        {
            return new Store
            {
                Name = createStoreDto.Name,
                Address = createStoreDto.Address,
                PhoneNumber = createStoreDto.PhoneNumber,
                ImageUrl = createStoreDto.ImageUrl
            };
        }

        //Update Store (Put)
        public static void ToStoreFromUpdate(Store store, UpdateStoreDto updateStoreDto)
        {
            store.Name = updateStoreDto.Name;
            store.Address = updateStoreDto.Address;
            store.PhoneNumber = updateStoreDto.PhoneNumber;
            store.ImageUrl = updateStoreDto.ImageUrl;

        }
    }
}

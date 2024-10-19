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
                Cars = store.Cars.Select(c => c.ToCarDto()).ToList()
            };
        }

        // Converts a StoreDto back to a Store model
        public static Store? ToStore(this StoreDto storeDto)
        {
            if (storeDto == null) return null;

            return new Store
            {
                Id = storeDto.Id,
                Name = storeDto.Name,
                Address = storeDto.Address,
                PhoneNumber = storeDto.PhoneNumber
            };
        }

        //Create Store (Post)
        public static Store ToStoreFromCreate(this Store store) 
        {
            return new Store
            {
                Name = store.Name,
                Address = store.Address,
                PhoneNumber = store.PhoneNumber
            };
        }

        //Update Store (Post)
        public static Store ToStoreFromUpdate(this Store store)
        {
            return new Store
            {
                Name = store.Name,
                Address = store.Address,
                PhoneNumber = store.PhoneNumber
            };
        }
    }
}

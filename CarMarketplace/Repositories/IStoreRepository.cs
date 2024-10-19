using CarMarketplace.Helpers;
using CarMarketplace.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarMarketplace.Repositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStores(StoreQueryObject storeQuery);
        Task<Store?> GetStoreById(int storeId);
        Task AddStore(Store store);
        Task UpdateStore(Store store);
        Task DeleteStore(int storeId);
        Task<bool> StoreExists(int storeId);
    }
}

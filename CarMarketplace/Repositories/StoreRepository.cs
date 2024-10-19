using CarMarketplace.Data;
using CarMarketplace.Helpers;
using CarMarketplace.Mappers;
using CarMarketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMarketplace.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ApplicationDbContext _context;
        public StoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetAllStores(StoreQueryObject storeQuery)
        {
            var stores = _context.Stores.Include(s => s.Cars).AsQueryable();
            if (!string.IsNullOrWhiteSpace(storeQuery.Name))
            {
                stores = stores.Where(s => s.Name.Contains(storeQuery.Name));
            }
            if (!string.IsNullOrWhiteSpace(storeQuery.SortBy))
            {
                if (storeQuery.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    stores = storeQuery.IsDescending ? stores.OrderByDescending(s => s.Name) : stores.OrderBy(s => s.Name);
                }
            }

            var skipNumber = (storeQuery.PageNumber - 1) * storeQuery.PageSize;

            return await stores.Skip(skipNumber).Take(storeQuery.PageSize).ToListAsync();
        }

        public async Task<Store?> GetStoreById(int storeId)
        {
            return await _context.Stores.Include(s => s.Cars).FirstOrDefaultAsync(s => s.Id == storeId);
        }

        public async Task AddStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStore(Store store)
        {
            _context.Stores.Update(store);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStore(int storeId)
        {
            var store = _context.Stores.Find(storeId);
            if (store != null) 
            {
                _context.Stores.Remove(store);
                await _context.SaveChangesAsync();
            }
        }

        public Task<bool> StoreExists(int storeId)
        {
            return _context.Stores.AnyAsync(s => s.Id == storeId);
        }
    }
}

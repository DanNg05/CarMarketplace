using AutoMapper;
using CarMarketplace.Data;
using CarMarketplace.DTOs.Car;
using CarMarketplace.DTOs.Store;
using CarMarketplace.Helpers;
using CarMarketplace.Mappers;
using CarMarketplace.Models;
using CarMarketplace.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMarketplace.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class StoresController : Controller
    {

        private readonly IStoreRepository _storeRepository;
        public StoresController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        // GET: api/stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreDto>>> GetStores([FromQuery] StoreQueryObject storeQuery)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stores = await _storeRepository.GetAllStores(storeQuery);
            var storeDtos = stores.Select(StoreMappers.ToStoreDto).ToList(); 
            return Ok(storeDtos);
        }

        // GET: api/store/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDto>> GetStore(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var store = await _storeRepository.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(StoreMappers.ToStoreDto(store));
        }

        // POST: api/store
        [HttpPost]
        public async Task<ActionResult<StoreDto>> PostStore(StoreDto storeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (storeDto == null)
            {
                return BadRequest("Store data cannot be null.");
            }

            var store = storeDto.ToStore(); 

            if (store == null)
            {
                return BadRequest("Failed to map StoreDto to Store.");
            }

            await _storeRepository.AddStore(store); 

            return CreatedAtAction("GetStore", new { id = store.Id }, store.ToStoreDto());
        }

        // PUT: api/store/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(int id, StoreDto  storeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (storeDto == null)
            {
                return BadRequest("Store data cannot be null.");
            }

            if (id != storeDto.Id)
            {
                return BadRequest("Store ID mismatch.");
            }

            var store = storeDto.ToStore(); 

            if (store == null)
            {
                return BadRequest("Store could not be mapped.");
            }

            await _storeRepository.UpdateStore(store); 

            return NoContent();
        }

        // DELETE: api/store/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _storeRepository.DeleteStore(id);
            return NoContent();
        }
    }
}

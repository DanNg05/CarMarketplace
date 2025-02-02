using AutoMapper;
using CarMarketplace.Data;
using CarMarketplace.DTOs.Car;
using CarMarketplace.DTOs.Store;
using CarMarketplace.Helpers;
using CarMarketplace.Mappers;
using CarMarketplace.Models;
using CarMarketplace.Repositories;
using CarMarketplace.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMarketplace.Controllers
{
    [Route("api/stores")]
    [ApiController]
    public class StoresController : Controller
    {

        private readonly IStoreRepository _storeRepository;
        private readonly ImageService _imageService;
        public StoresController(IStoreRepository storeRepository, ImageService imageService)
        {
            _storeRepository = storeRepository;
            _imageService = imageService;
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

        public async Task<ActionResult<StoreDto>> PostStore([FromForm] CreateStoreDto createStoreDto, IFormFile image)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (createStoreDto == null)
            {
                return BadRequest("Store data cannot be null.");
            }


            string imageUrl = string.Empty;

            // Upload image to Cloudinary if an image file is provided
            if (image != null)
            {
                imageUrl = await _imageService.UploadImageAsync(image);
                if (string.IsNullOrEmpty(imageUrl))
                {
                    return BadRequest("Failed to upload image.");
                }
            }

            var store = StoreMappers.ToStoreFromCreate(createStoreDto);
            store.ImageUrl = imageUrl;

            await _storeRepository.AddStore(store); 

            return CreatedAtAction("GetStore", new { id = store.Id }, store.ToStoreDto());
        }

        // PUT: api/store/{id}
        [HttpPut("{id}")]

        public async Task<IActionResult> PutStore(int id, [FromForm] UpdateStoreDto  updateStoreDto, IFormFile? image)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (updateStoreDto == null)
            {
                return BadRequest("Store data cannot be null.");
            }

            var existingStore = await _storeRepository.GetStoreById(id);
            if (existingStore == null)
            {
                return NotFound("Store not found.");
            }

            string imageUrl = existingStore.ImageUrl; // Retain the existing image URL if no new file is uploaded

            // Upload new image to Cloudinary if an image file is provided
            if (image != null)
            {
                imageUrl = await _imageService.UploadImageAsync(image);
                if (string.IsNullOrEmpty(imageUrl))
                {
                    return BadRequest("Failed to upload image.");
                }
            }
            StoreMappers.ToStoreFromUpdate(existingStore, updateStoreDto);
            existingStore.ImageUrl = imageUrl;
            
            await _storeRepository.UpdateStore(existingStore);


            return Ok(existingStore);
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

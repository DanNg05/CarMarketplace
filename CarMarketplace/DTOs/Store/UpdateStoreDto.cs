﻿using CarMarketplace.DTOs.Car;

namespace CarMarketplace.DTOs.Store
{
    public class UpdateStoreDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        //public IFormFile? ImageFile { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<CarDto> Cars { get; set; } = new List<CarDto>();
    }
}

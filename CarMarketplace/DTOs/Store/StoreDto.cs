using CarMarketplace.DTOs.Car;

namespace CarMarketplace.DTOs.Store
{
    public class StoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<CarDto> Cars { get; set; } = new List<CarDto>();
    }
}

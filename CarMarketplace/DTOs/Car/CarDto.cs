using CarMarketplace.Models;

namespace CarMarketplace.DTOs.Car
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Odometer { get; set; } = string.Empty;
        public int Price { get; set; }
        public int? StoreId { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}

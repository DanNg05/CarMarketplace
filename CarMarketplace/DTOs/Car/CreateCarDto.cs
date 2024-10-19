namespace CarMarketplace.DTOs.Car
{
    public class CreateCarDto
    {
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Odometer { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}

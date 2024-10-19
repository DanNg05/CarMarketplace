using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Odometer cannot be less than 0.")]
        public string Odometer { get; set; } = string.Empty;
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be less than 0.")]
        public int Price { get; set; }
        public int? StoreId { get; set; }
        public Store? Store { get; set; }
    }
}

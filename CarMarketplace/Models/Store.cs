using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public class Store
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        //[RegularExpression(@"^\d+$", ErrorMessage = "Phone number must contain numbers only.")]
        //[StringLength(10, ErrorMessage = "Phone number must be 10 digits long.", MinimumLength = 10)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}

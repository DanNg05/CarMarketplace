namespace CarMarketplace.Models
{
    public class EmailRequest
    {
        public string UserEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}

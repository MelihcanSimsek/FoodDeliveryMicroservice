namespace WebApp.Models.Restaurant
{
    public class RestaurantQueryRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.MaxValue;
    }
}

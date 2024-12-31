namespace WebApp.Models.Restaurant
{
    public class CreateRestaurantRequest
    {
        public string Name { get; set; }
        public string EmailContact { get; set; }
        public string PhoneContact { get; set; }
        public string Country { get; set; }

        public CreateRestaurantRequest()
        {
        }
    }
}

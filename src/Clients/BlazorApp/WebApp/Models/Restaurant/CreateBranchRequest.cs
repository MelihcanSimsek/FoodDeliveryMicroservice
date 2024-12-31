namespace WebApp.Models.Restaurant
{
    public class CreateBranchRequest
    {
        public Guid RestaurantId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public CreateBranchRequest()
        {
        }
    }
}


using MediatR;
using Restaurant.Application.Interfaces.Authorization;

namespace Restaurant.Application.Features.Restaurants.Commands.RestaurantCreate
{
    public class RestaurantCreateCommandRequest :IRequest<Unit>,ISecuredRequest
    {
        public string Name { get; set; }
        public string EmailContact { get; set; }
        public string PhoneContact { get; set; }
        public string Country { get; set; }

        public string[] Roles => ["restaurantadmin"];

    }
}

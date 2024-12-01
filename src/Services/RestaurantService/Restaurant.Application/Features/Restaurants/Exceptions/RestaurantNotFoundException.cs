using Restaurant.Application.Exceptions;
using Restaurant.Application.Features.Restaurants.Constants;


namespace Restaurant.Application.Features.Restaurants.Exceptions
{
    public class RestaurantNotFoundException : BusinessException
    {
        public RestaurantNotFoundException() : base(Messages.RestaurantNotFound)
        {
            
        }
    }
}

using Restaurant.Application.Bases;
using Restaurant.Application.Features.Restaurants.Exceptions;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Restaurants.Rules
{
    public class RestaurantRules : BaseRules
    {
        public async Task ShouldRestaurantExists(Restaurant.Domain.Entities.Restaurant? restaurant)
        {
            if (restaurant is null) throw new RestaurantNotFoundException();
        }

        public async Task ShouldRestaurantNameCanNotBeDuplicated(Restaurant.Domain.Entities.Restaurant? restauran)
        {
            if (restauran is not null) throw new RestaurantNameCanNotBeDuplicatedException();
        }
    }
}

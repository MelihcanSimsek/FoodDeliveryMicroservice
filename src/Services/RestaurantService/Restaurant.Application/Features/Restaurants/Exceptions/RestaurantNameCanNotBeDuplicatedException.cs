using Restaurant.Application.Exceptions;
using Restaurant.Application.Features.Restaurants.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Restaurants.Exceptions
{
    public class RestaurantNameCanNotBeDuplicatedException : BusinessException
    {
        public RestaurantNameCanNotBeDuplicatedException():base(Messages.RestaurantNameCanNotBeDuplicate)
        {
            
        }
    }
}

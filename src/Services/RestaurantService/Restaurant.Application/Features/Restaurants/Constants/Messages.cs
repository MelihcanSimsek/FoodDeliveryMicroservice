using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Restaurants.Constants
{
    public static class Messages
    {
        public static string RestaurantNameCanNotBeDuplicate = "Restaurant name can not be duplicated";
        public static string RestaurantNotFound = "Restaurant not found";
        public static string RequestIdDoesNotMatch = "Request id does not match, you are not authorized.";
    }
}

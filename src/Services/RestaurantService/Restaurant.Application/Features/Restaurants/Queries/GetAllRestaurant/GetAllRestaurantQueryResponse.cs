using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Restaurants.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}

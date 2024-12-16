using MediatR;
using Restaurant.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Restaurants.Commands.RestaurantDelete
{
    public class RestaurantDeleteCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public string[] Roles => ["restaurantworker"];
    }
}

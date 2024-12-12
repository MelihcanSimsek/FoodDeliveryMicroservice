using BasketService.Application.Interfaces.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Commands.StartOrder
{
    public class StartOrderCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public string RestaurantAddress { get; set; }
        public string UserEmail { get; set; }
        public string Address { get; set; }
        public string[] Roles => ["user"];
    }
}

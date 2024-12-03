using BasketService.Application.Interfaces.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Commands.DeletAllBasket
{
    public class DeleteAllBasketCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public string[] Roles => ["user"];
    }
}

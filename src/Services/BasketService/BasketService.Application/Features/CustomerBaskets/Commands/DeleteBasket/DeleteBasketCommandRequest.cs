using BasketService.Application.Interfaces.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Commands.DeleteBasket
{
    public class DeleteBasketCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public Guid Id { get; set; }
        public string[] Roles => ["user"];
    }
}

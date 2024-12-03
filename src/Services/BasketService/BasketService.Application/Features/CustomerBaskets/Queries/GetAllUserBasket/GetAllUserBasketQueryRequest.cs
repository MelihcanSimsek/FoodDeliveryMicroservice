using BasketService.Application.Interfaces.Authorization;
using BasketService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Queries.GetAllUserBasket
{
    public class GetAllUserBasketQueryRequest : IRequest<IList<BasketItem>>
    {
        public string[] Roles => ["user"];
    }
}

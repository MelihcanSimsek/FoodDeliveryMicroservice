using BasketService.Application.Interfaces.Authorization;
using BasketService.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Commands.UpdateBasket
{
    public class UpdateBasketCommandRequest :IRequest<Unit>
    {
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public string MenuName { get; set; }
        public int Type { get; set; } 
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }

        public string[] Roles => ["user"];
    }
}

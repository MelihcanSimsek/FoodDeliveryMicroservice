using MediatR;
using RestaurantOrderService.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Commands.ChangeOrderStatusToRejected
{
    public class ChangeOrderStatusToRejectedCommandRequest : ISecuredRequest , IRequest<Unit>
    {
        public Guid OrderNumber { get; set; }

        public string[] Roles => ["delivery.owner.restaurant"];
    }
}

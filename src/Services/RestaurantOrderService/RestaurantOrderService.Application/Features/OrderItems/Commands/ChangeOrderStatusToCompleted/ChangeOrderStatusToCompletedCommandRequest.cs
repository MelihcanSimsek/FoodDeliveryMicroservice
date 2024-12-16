using MediatR;
using RestaurantOrderService.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Commands.ChangeOrderStatusToCompleted
{
    public class ChangeOrderStatusToCompletedCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public Guid OrderNumber { get; set; }
        public string[] Roles => ["restaurantworker"];
    }
}

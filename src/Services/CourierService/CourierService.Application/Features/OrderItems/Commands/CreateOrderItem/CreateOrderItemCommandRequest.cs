using CourierService.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandRequest : IRequest<bool>
    {
        public Guid OrderNumber { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }
        public string RestaurantAddress { get; set; }
        public string UserEmail { get; set; }
        public string Address { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.PENDING;
        public Guid? CourierUserId { get; set; } = null;
    }
}

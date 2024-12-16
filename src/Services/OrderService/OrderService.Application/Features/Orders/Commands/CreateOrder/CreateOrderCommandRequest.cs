using MediatR;
using OrderService.Application.Features.Orders.IntegrationEvents.Events;

namespace OrderService.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public List<EventOrderItem> EventOrderItems { get; set; }
    }
}

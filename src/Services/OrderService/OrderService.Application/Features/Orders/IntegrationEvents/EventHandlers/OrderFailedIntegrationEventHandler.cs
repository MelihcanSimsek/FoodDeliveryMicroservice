using EventBus.Base.Abstraction;
using MediatR;
using OrderService.Application.Features.Orders.Commands.ChangeOrderStatusToFailed;
using OrderService.Application.Features.Orders.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.IntegrationEvents.EventHandlers
{
    public class OrderFailedIntegrationEventHandler : IIntegrationEventHandler<OrderFailedIntegrationEvent>
    {
        private readonly IMediator mediator;

        public OrderFailedIntegrationEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(OrderFailedIntegrationEvent @event)
        {
            await mediator.Send(new ChangeOrderStatusToFailedCommandRequest() { FailMessage = @event.FailMessage, OrderNumber = @event.OrderNumber });
        }
    }
}

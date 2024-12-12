using EventBus.Base.Abstraction;
using MediatR;
using OrderService.Application.Features.Orders.Commands.ChangeOrderStatusToCompleted;
using OrderService.Application.Features.Orders.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.IntegrationEvents.EventHandlers
{
    public class OrderCompletedIntegrationEventHandler : IIntegrationEventHandler<OrderCompletedIntegrationEvent>
    {
        private readonly IMediator mediator;

        public OrderCompletedIntegrationEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(OrderCompletedIntegrationEvent @event)
        {
            await mediator.Send(new ChangeOrderStatusToCompletedCommandRequest() { OrderNumber = @event.OrderNumber });
        }
    }
}

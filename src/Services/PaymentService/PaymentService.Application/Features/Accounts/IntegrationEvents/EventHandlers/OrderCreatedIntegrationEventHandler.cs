using EventBus.Base.Abstraction;
using MediatR;
using PaymentService.Application.Features.Accounts.Commands.UpdateBalanceForOrder;
using PaymentService.Application.Features.Accounts.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.IntegrationEvents.EventHandlers
{
    public class OrderCreatedIntegrationEventHandler : IIntegrationEventHandler<OrderCreatedIntegrationEvent>
    {
        private readonly IMediator mediator;

        public OrderCreatedIntegrationEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(OrderCreatedIntegrationEvent @event)
        {
            var request = new DownBalanceForOrderCommandRequest()
            {
               EventPaymentItems=@event.EventPaymentItems,
               UserId = @event.UserId
            };

            await mediator.Send(request);
        }
    }
}

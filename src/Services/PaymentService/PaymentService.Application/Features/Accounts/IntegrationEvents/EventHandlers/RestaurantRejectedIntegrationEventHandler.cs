using EventBus.Base.Abstraction;
using MediatR;
using PaymentService.Application.Features.Accounts.Commands.UpBalanceForOrder;
using PaymentService.Application.Features.Accounts.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.IntegrationEvents.EventHandlers
{
    public class RestaurantRejectedIntegrationEventHandler : IIntegrationEventHandler<RestaurantRejectedIntegrationEvent>
    {
        private readonly IMediator mediator;
        public RestaurantRejectedIntegrationEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(RestaurantRejectedIntegrationEvent @event)
        {
            var request = new UpBalanceForOrderCommandRequest()
            {
                FailMessage = @event.FailMessage,
                UserEmail = @event.UserEmail,
                UserId = @event.UserId,
                OrderNumber = @event.OrderNumber,
                Quantity = @event.Quantity,
                UnitPrice = @event.UnitPrice,
                Type = typeof(RestaurantRejectedIntegrationEvent)
            };
            await mediator.Send(request);
        }
    }
}

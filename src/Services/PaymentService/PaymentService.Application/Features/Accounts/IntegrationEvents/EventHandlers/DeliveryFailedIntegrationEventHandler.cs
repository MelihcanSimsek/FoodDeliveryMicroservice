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
    public class DeliveryFailedIntegrationEventHandler : IIntegrationEventHandler<DeliveryFailedIntegrationEvent>
    {
        private readonly IMediator mediator;

        public DeliveryFailedIntegrationEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(DeliveryFailedIntegrationEvent @event)
        {
            var request = new UpBalanceForOrderCommandRequest()
            {
                FailMessage=@event.FailMessage,
                OrderNumber=@event.OrderNumber,
                Quantity=@event.Quantity,
                UnitPrice=@event.UnitPrice,
                UserEmail=@event.UserEmail,
                UserId=@event.UserId,
                Type=typeof(DeliveryFailedIntegrationEvent)
            };

            await mediator.Send(request);
        }
    }
}

using EventBus.Base.Abstraction;
using MediatR;
using RestaurantOrderService.Application.Features.OrderItems.Commands.CreateOrderItem;
using RestaurantOrderService.Application.Features.OrderItems.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.IntegrationEvents.EventHandlers
{
    public class PaymentSuccessIntegrationEventHandler : IIntegrationEventHandler<PaymentSuccessIntegrationEvent>
    {
        private readonly IMediator mediator;

        public PaymentSuccessIntegrationEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(PaymentSuccessIntegrationEvent @event)
        {
            var request = new CreateOrderItemCommandRequest()
            {
                Address = @event.Address,
                BranchId = @event.BranchId,
                MenuName = @event.MenuName,
                OrderNumber = @event.OrderNumber,
                Quantity = @event.Quantity,
                RestaurantAddress = @event.RestaurantAddress,
                RestaurantId = @event.RestaurantId,
                UnitPrice = @event.UnitPrice,
                UserEmail = @event.UserEmail,
                UserId = @event.UserId
            };

            await mediator.Send(request);
        }
    }
}

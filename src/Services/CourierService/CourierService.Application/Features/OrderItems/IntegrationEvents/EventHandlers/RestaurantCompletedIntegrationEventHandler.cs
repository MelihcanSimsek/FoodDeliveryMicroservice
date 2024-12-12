using CourierService.Application.Features.OrderItems.Commands.CreateOrderItem;
using CourierService.Application.Features.OrderItems.IntegrationEvents.Events;
using CourierService.Domain.Enums;
using EventBus.Base.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.IntegrationEvents.EventHandlers
{
    public class RestaurantCompletedIntegrationEventHandler : IIntegrationEventHandler<RestaurantCompletedIntegrationEvent>
    {
        private readonly IMediator mediator;

        public RestaurantCompletedIntegrationEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(RestaurantCompletedIntegrationEvent @event)
        {
            var request = new CreateOrderItemCommandRequest()
            {
                Address=@event.Address,
                BranchId= @event.BranchId,
                OrderNumber= @event.OrderNumber,
                RestaurantAddress= @event.RestaurantAddress,
                Quantity= @event.Quantity,
                RestaurantId= @event.RestaurantId,
                UnitPrice= @event.UnitPrice,
                UserEmail= @event.UserEmail,
                UserId= @event.UserId
            };

            await mediator.Send(request);
        }
    }
}

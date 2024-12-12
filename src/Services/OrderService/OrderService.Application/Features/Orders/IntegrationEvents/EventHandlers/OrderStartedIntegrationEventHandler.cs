using EventBus.Base.Abstraction;
using MediatR;
using OrderService.Application.Features.Orders.Commands.CreateOrder;
using OrderService.Application.Features.Orders.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.IntegrationEvents.EventHandlers
{
    public class OrderStartedIntegrationEventHandler : IIntegrationEventHandler<OrderStartedIntegrationEvent>
    {
        private readonly IMediator mediator;

        public OrderStartedIntegrationEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(OrderStartedIntegrationEvent @event)
        {
            foreach (var item in @event.EvenOrderItems)
            {
                var createOrderRequest = new CreateOrderCommandRequest()
                {
                    MenuName = item.MenuName,
                    BranchId = item.BranchId,
                    Quantity = item.Quantity,
                    RestaurantId = item.RestaurantId,
                    Type = item.Type,
                    UnitPrice = item.UnitPrice,
                    UserEmail = item.UserEmail,
                    Address = item.Address,
                    RestaurantAddress = item.RestaurantAddress,
                    UserId = @event.UserId
                };

               var response =  await mediator.Send(createOrderRequest);
            }

            Task.CompletedTask.Wait();
        }
    }
}

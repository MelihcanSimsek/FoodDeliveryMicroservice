﻿using EventBus.Base.Abstraction;
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
            var createOrderRequest = new CreateOrderCommandRequest()
            {
               UserId=@event.UserId,
               EventOrderItems=@event.EventOrderItems
            };
            await mediator.Send(createOrderRequest);
        }
    }
}

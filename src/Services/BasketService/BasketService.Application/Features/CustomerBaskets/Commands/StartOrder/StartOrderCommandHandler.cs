﻿using BasketService.Application.Extensions;
using BasketService.Application.Features.CustomerBaskets.IntegrationEvents.Events;
using BasketService.Application.Features.CustomerBaskets.Rules;
using BasketService.Application.Interfaces.Repositories;
using BasketService.Domain.Entities;
using EventBus.Base.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Commands.StartOrder
{
    public class StartOrderCommandHandler : IRequestHandler<StartOrderCommandRequest, Unit>
    {
        private readonly ICustomerBasketRepository customerBasketRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly CustomerBasketRules customerBasketRules;
        private readonly IEventBus eventBus;

        public StartOrderCommandHandler(ICustomerBasketRepository customerBasketRepository, IHttpContextAccessor httpContextAccessor, CustomerBasketRules customerBasketRules, IEventBus eventBus)
        {
            this.customerBasketRepository = customerBasketRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.customerBasketRules = customerBasketRules;
            this.eventBus = eventBus;
        }

        public async Task<Unit> Handle(StartOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = httpContextAccessor.HttpContext.User.GetUserId();
            CustomerBasket customerBasket = await customerBasketRepository.GetBasketAsync(userId.ToString());
            IList<BasketItem> basketItems = customerBasket.BasketItems;
            await customerBasketRules.ShouldBasketItemsExists(basketItems);

            List<EvenOrderItem> eventItem = new List<EvenOrderItem>();

            foreach (var item in basketItems)
            {
                eventItem.Add(new EvenOrderItem(item.RestaurantId, item.BranchId,
                    item.MenuName, item.Type.ToString(), item.UnitPrice, item.Quantity, request.UserEmail, request.Address, request.RestaurantAddress));

            }

            var orderCreatedEvent = new OrderStartedIntegrationEvent(userId, eventItem);

            await customerBasketRepository.DeleteBasketAsync(userId.ToString());
            eventBus.Publish(orderCreatedEvent);

            return Unit.Value;
        }
    }
}

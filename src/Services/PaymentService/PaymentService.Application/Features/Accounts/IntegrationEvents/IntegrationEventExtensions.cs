using EventBus.Base.Abstraction;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PaymentService.Application.Features.Accounts.IntegrationEvents.EventHandlers;
using PaymentService.Application.Features.Accounts.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.IntegrationEvents
{
    public static class IntegrationEventExtensions
    {
        public static void ConfigureCustomEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();
            eventBus.Subscribe<RestaurantRejectedIntegrationEvent, RestaurantRejectedIntegrationEventHandler>();
            eventBus.Subscribe<DeliveryFailedIntegrationEvent, DeliveryFailedIntegrationEventHandler>();
        }
    }
}

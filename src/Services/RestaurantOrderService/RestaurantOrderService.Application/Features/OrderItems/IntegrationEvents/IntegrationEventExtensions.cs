using EventBus.Base.Abstraction;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RestaurantOrderService.Application.Features.OrderItems.IntegrationEvents.EventHandlers;
using RestaurantOrderService.Application.Features.OrderItems.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.IntegrationEvents
{
    public static class IntegrationEventExtensions
    {
        public static void ConfigureCustomEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<PaymentSuccessIntegrationEvent, PaymentSuccessIntegrationEventHandler>();
        }
    }
}

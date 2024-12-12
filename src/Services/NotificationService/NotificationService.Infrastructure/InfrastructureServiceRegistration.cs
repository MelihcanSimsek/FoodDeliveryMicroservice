using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.Infrastructure.IntegrationEvents.EventHandlers;
using NotificationService.Infrastructure.MailServices;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();
            services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new()
                {
                    ConnectionRetryCount = 5,
                    EventNameSuffix = "IntegrationEvent",
                    SubscriberClientAppName = "NotificationService",
                    EventBusType = EventBusType.RabbitMQ,
                };

                return EventBusFactory.Create(config, sp);
            });

            services.AddTransient<NotificationEmailIntegrationEventHandler>();

            return services;
        }
    }
}

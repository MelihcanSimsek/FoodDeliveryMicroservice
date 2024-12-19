using CourierService.Application.Bases;
using CourierService.Application.Behaviours;
using CourierService.Application.Exceptions;
using MediatR;
using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using EventBus.Factory;
using RabbitMQ.Client;
using EventBus.Base;
using EventBus.Base.Abstraction;
using CourierService.Application.Features.OrderItems.IntegrationEvents.EventHandlers;
namespace CourierService.Application
{
    public static class Registrations
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient<ExceptionMiddleware>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            services.AddEventBus();
            return services;
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var rules = assembly.GetTypes().Where(p => p.IsSubclassOf(type) && p != type);

            foreach (var rule in rules)
                services.AddTransient(rule);

            return services;
        }

        private static IServiceCollection AddEventBus(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new()
                {
                    ConnectionRetryCount = 5,
                    EventNameSuffix = "IntegrationEvent",
                    SubscriberClientAppName = "CourierService",
                    EventBusType = EventBusType.RabbitMQ,
                    Connection = new ConnectionFactory()
                    {
                        HostName = "c_rabbitmq"
                    }
                };

                return EventBusFactory.Create(config, sp);
            });

            services.AddTransient<RestaurantCompletedIntegrationEventHandler>();

            return services;
        }
    }
}

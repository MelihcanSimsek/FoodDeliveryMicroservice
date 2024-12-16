using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Identity.Application.Exceptions;
using Identity.Application.Bases;
using Identity.Application.Behaviours;
using MediatR;
using EventBus.Factory;
using RabbitMQ.Client;
using EventBus.Base.Abstraction;
using EventBus.Base;



namespace Identity.Application
{
    public static class Registration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient<ExceptionMiddleware>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddEventBus();

            return services;
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,Assembly assembly,Type type)
        {
            var rules = assembly.GetTypes().Where(p => p.IsSubclassOf(type) && type != p);

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
                    SubscriberClientAppName = "IdentityService",
                    EventBusType = EventBusType.RabbitMQ,
                };

                return EventBusFactory.Create(config, sp);
            });

            return services;
        }
    }
}

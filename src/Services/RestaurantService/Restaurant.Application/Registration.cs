using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Bases;
using Restaurant.Application.Behaviours;
using Restaurant.Application.Exceptions;
using Restaurant.Application.Interfaces.Mapper;
using System.Reflection;

namespace Restaurant.Application
{
    public static class Registration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            services.AddSingleton<IMapper, Restaurant.Application.Mapper.Mapper>();

            services.AddTransient<ExceptionMiddleware>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddRulesFromAssemblyContaining(assembly,typeof(BaseRules));

            return services;
        }
        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,Assembly assembly,Type type)
        {
            var rules = assembly.GetTypes().Where(p => p.IsSubclassOf(type) && p != type);

            foreach (var rule in rules)
                services.AddTransient(rule);

            return services;
        }
    }
}

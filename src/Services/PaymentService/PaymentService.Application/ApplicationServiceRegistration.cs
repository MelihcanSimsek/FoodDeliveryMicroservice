using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using PaymentService.Application.Bases;
using PaymentService.Application.Exceptions;
using PaymentService.Application.Behaviours;

namespace PaymentService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient<ExceptionMiddleware>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            return services;
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var rules = assembly.GetTypes().Where(p => p.IsSubclassOf(type) && p != type);

            foreach (var rule in rules)
                services.AddTransient(rule);

            return services;
        }
    }
}

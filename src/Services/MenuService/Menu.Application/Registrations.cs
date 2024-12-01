using FluentValidation;
using MediatR;
using Menu.Application.Bases;
using Menu.Application.Behaviours;
using Menu.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application
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
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisRemoveBehaviour<,>));

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

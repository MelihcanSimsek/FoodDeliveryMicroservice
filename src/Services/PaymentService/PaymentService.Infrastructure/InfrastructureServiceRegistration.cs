using Microsoft.Extensions.DependencyInjection;
using PaymentService.Application.Interfaces.CustomMapper;
using PaymentService.Application.Interfaces.FakePayments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, CustomMapper.Mapper>();
            services.AddSingleton<IPaymentService, FakePayment.PaymentService>();
            return services;
        }
    }
}

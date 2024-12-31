using WebApp.Services.Abstracts;
using WebApp.Services.Concretes;

namespace WebApp.Services
{
    public static class Registrations
    {
        public static IServiceCollection WebAppServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ICourierService, CourierService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IRestaurantOrderService, RestaurantOrderService>();
            services.AddScoped<IRestaurantService, RestaurantService>();

            return services;
        }
    }
}

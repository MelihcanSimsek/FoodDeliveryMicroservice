using Microsoft.OpenApi.Models;

namespace PaymentService.Api.Registrations
{
    public static class SwaggerRegistration
    {
        public static IServiceCollection AddSwaggerRegistration(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Payment Service",
                        Version = "v1",
                        Description = "This is a Payment Service API Documentation"
                    });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345.54321\""
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
            new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            new string[] { }
                    }
                });
            });

            return services;
        }

    }
}

using OrderService.Application;
using OrderService.Persistence;
using OrderService.Infrastructure;
using OrderService.Api.Registrations;
using OrderService.Application.Exceptions;
using OrderService.Application.Features.Orders.IntegrationEvents;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddApplicationRegistration();
builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Services.AddInfrastructureRegistration();

builder.Services.AddAuthenticationRegistration(builder.Configuration);
builder.Services.AddConsulRegistration(builder.Configuration);
builder.Services.AddSwaggerRegistration();

builder.Configuration
    .AddEnvironmentVariables();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Services.MigrateDatabase();
app.ConfigureCustomExceptionMiddleware();
app.ConfigureCustomEventBus();
app.RegisterWithConsul(app.Lifetime, builder.Configuration);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

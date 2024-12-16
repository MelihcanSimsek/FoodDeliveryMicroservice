using Identity.Infrastructure;
using Identity.Persistence;
using Identity.Application;
using Identity.Api.Registrations;
using Identity.Application.Exceptions;
using Microsoft.OpenApi.Models;
using Identity.Application.Features.Auth.IntegrationEvents;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration();
builder.Services.AddAuthenticationRegistration(builder.Configuration);
builder.Services.AddConsulRegistration(builder.Configuration);
builder.Services.AddSwaggerRegistration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.ConfigureCustomExceptionMiddleware();
app.RegisterWithConsul(app.Lifetime, app.Configuration);
app.ConfigureCustomEventBus();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

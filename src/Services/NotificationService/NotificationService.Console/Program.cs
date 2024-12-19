using Microsoft.Extensions.DependencyInjection;
using NotificationService.Infrastructure;
using EventBus.Base.Abstraction;
using NotificationService.Infrastructure.IntegrationEvents.Events;
using NotificationService.Infrastructure.IntegrationEvents.EventHandlers;

Console.WriteLine("------------ Starting Notification Service Be Ready Right Now ------------");
IServiceCollection services = new ServiceCollection();

services.AddInfrastructureRegistration();

var sp = services.BuildServiceProvider();
var eventBus = sp.GetRequiredService<IEventBus>();
eventBus.Subscribe<NotificationEmailIntegrationEvent, NotificationEmailIntegrationEventHandler>();

Console.WriteLine("Listening for events. Press [Enter] to exit.");
Console.ReadLine();
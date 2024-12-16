using EventBus.Base.Abstraction;
using EventBus.Base.SubManagers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Base.Events
{
    public abstract class BaseEventBus : IEventBus, IDisposable
    {
        public readonly IServiceProvider ServiceProvider;
        public readonly IEventBusSubscriptionManager SubsManager;
        public EventBusConfig EventBusConfig { get; private set; }

        public BaseEventBus(EventBusConfig config,IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
            this.EventBusConfig = config;
            this.SubsManager = new InMemoryEventBusSubscriptionManager(ProcessEventName);
        }

        public virtual string ProcessEventName(string eventName)
        {
            if(EventBusConfig.DeleteEventPrefix)
                eventName = eventName.TrimStart(EventBusConfig.EventNamePrefix.ToArray());
            if(EventBusConfig.DeleteEventSuffix)
                eventName = eventName.TrimEnd(EventBusConfig.EventNameSuffix.ToArray());

            return eventName;
        }
        public virtual string GetSubName(string eventName)
        {
            return $"{EventBusConfig.SubscriberClientAppName}.{ProcessEventName(eventName)}";
        }

        public virtual void Dispose()
        {
            EventBusConfig = null;
            SubsManager.Clear();
        }

        public async Task<bool> ProcessEvent(string eventName, string message)
        {
            eventName = ProcessEventName(eventName);
            bool processed = false;

            if (SubsManager.HasSubscriptionsForEvent(eventName))
            {
                var subscriptions = SubsManager.GetHandlersForEvent(eventName);
                using (var scope = ServiceProvider.CreateScope())
                {
                    var scopedServiceProvider = scope.ServiceProvider;

                    foreach (var subscription in subscriptions)
                    {
                        var handler = scopedServiceProvider.GetService(subscription.HandlerType);
                        if (handler == null)
                        {
                            Console.WriteLine($"Handler not found for type: {subscription.HandlerType.Name}");
                            continue;
                        }

                        var eventType = SubsManager.GetEventTypeByName(
                            $"{EventBusConfig.EventNamePrefix}{eventName}{EventBusConfig.EventNameSuffix}");

                        if (eventType == null)
                        {
                            Console.WriteLine($"Event type not found for event name: {eventName}");
                            continue;
                        }

                        object integrationEvent;
                        try
                        {
                            integrationEvent = JsonConvert.DeserializeObject(message, eventType);
                        }
                        catch (JsonException ex)
                        {
                            Console.WriteLine($"Failed to deserialize message: {ex.Message}");
                            continue;
                        }

                        var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                        var handleMethod = concreteType.GetMethod("Handle");
                        if (handleMethod == null)
                        {
                            Console.WriteLine($"Handle method not found for type: {concreteType.Name}");
                            continue;
                        }

                        try
                        {
                            await (Task)handleMethod.Invoke(handler, new object[] { integrationEvent });
                        }
                        catch (TargetInvocationException ex)
                        {
                            Console.WriteLine($"Error invoking Handle method: {ex.InnerException?.Message}");
                            throw;
                        }
                    }
                }

                processed = true;
            }

            return processed;
        }

        public abstract void Publish(IntegrationEvent @event);

        public abstract void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        public abstract void UnSubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;
    }
}

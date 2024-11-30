using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.RabbitMQ;

namespace EventBus.Factory
{
    public static class EventBusFactory
    {
        public static IEventBus Create(EventBusConfig eventBusConfig,IServiceProvider serviceProvider)
        {
            return new EventBusRabbitMQ(eventBusConfig, serviceProvider);
        }
    }
}

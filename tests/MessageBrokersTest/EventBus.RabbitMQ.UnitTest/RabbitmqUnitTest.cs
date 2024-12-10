using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using EventBus.RabbitMQ.UnitTest.Events.EventHandlers;
using EventBus.RabbitMQ.UnitTest.Events.Events;
using Microsoft.Extensions.DependencyInjection;



namespace EventBus.RabbitMQ.UnitTest
{
    public class RabbitmqUnitTest
    {
        private ServiceCollection services;
        public RabbitmqUnitTest()
        {
            services = new ServiceCollection();
        }

        [Fact]
        public void Test_Subscribe_On_Rabbitmq()
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                return EventBusFactory.Create(GetRabbitMQConfig(), sp);
            });

            var sp = services.BuildServiceProvider();
            var eventBus = sp.GetRequiredService<IEventBus>();

            eventBus.Subscribe<OrderStartedIntegrationEvent, OrderStartedIntegrationEventHandler>();
            Task.Delay(300);
            //eventBus.UnSubscribe<OrderStartedIntegrationEvent, OrderStartedIntegrationEventHandler>();
        }

        [Fact]
        public void Test_Send_Message_To_Rabbitmq()
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                return EventBusFactory.Create(GetRabbitMQConfig(), sp);
            });

            var sp = services.BuildServiceProvider();
            var eventBus = sp.GetRequiredService<IEventBus>();

            eventBus.Publish(new OrderStartedIntegrationEvent(Guid.NewGuid(), "This is a test order message bla bla"));
        }


        private EventBusConfig GetRabbitMQConfig()
        {
            return new EventBusConfig()
            {
                ConnectionRetryCount = 5,
                SubscriberClientAppName = "EventBus.RabbitMQ.UnitTest",
                DefaultTopicName = "FoodDeliveryTopicName",
                EventBusType = EventBusType.RabbitMQ,
                EventNameSuffix = "IntegrationEvent",
            };
        }
    }
}

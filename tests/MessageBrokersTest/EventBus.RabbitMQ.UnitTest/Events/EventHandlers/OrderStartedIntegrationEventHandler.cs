using EventBus.Base.Abstraction;
using EventBus.RabbitMQ.UnitTest.Events.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.RabbitMQ.UnitTest.Events.EventHandlers
{
    public class OrderStartedIntegrationEventHandler : IIntegrationEventHandler<OrderStartedIntegrationEvent>
    {
        public Task Handle(OrderStartedIntegrationEvent @event)
        {
            Console.WriteLine("Id: " + @event.Id + " Name: " + @event.Name);
            Debug.WriteLine("------------------------------------");
            Debug.WriteLine("------------------------------------");
            Debug.WriteLine("------------------------------------");
            Debug.WriteLine("------------------------------------");
            Debug.WriteLine("------------------------------------");
            Debug.WriteLine("------------------------------------");
            Debug.WriteLine("Id: " + @event.Id + " Name: " + @event.Name);
            Debug.WriteLine("------------------------------------");
            Debug.WriteLine("------------------------------------");
            Debug.WriteLine("------------------------------------");
            Debug.WriteLine("------------------------------------");
            return Task.CompletedTask;
        }
    }
}

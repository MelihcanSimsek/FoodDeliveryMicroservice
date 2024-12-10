using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.RabbitMQ.UnitTest.Events.Events
{
    public class OrderStartedIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public OrderStartedIntegrationEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

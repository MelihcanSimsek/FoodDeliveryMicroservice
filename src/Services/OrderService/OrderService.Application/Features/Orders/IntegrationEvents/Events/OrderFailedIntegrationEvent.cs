using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.IntegrationEvents.Events
{
    public class OrderFailedIntegrationEvent : IntegrationEvent
    {
        public Guid OrderNumber { get; set; }
        public string FailMessage { get; set; }

        public OrderFailedIntegrationEvent(Guid orderNumber, string failMessage)
        {
            OrderNumber = orderNumber;
            FailMessage = failMessage;
        }
    }
}

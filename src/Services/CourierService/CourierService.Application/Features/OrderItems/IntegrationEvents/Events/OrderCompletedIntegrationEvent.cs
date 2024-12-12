using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.IntegrationEvents.Events
{
    public class OrderCompletedIntegrationEvent : IntegrationEvent
    {
        public Guid OrderNumber { get; set; }

        public OrderCompletedIntegrationEvent(Guid orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}

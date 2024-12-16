using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.IntegrationEvents.Events
{
    public class OrderCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; set; }
        public List<EventPaymentItem> EventPaymentItems { get; set; }

        public OrderCreatedIntegrationEvent(Guid userId, List<EventPaymentItem> eventPaymentItems)
        {
            UserId = userId;
            EventPaymentItems = eventPaymentItems;
        }
    }
}

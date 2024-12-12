using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.IntegrationEvents.Events
{
    public class RestaurantRejectedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; set; }
        public Guid OrderNumber { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string UserEmail { get; set; }
        public string FailMessage { get; set; }
        public RestaurantRejectedIntegrationEvent(Guid userId, Guid orderNumber, decimal unitPrice, int quantity, string userEmail, string failMessage)
        {
            UserId = userId;
            OrderNumber = orderNumber;
            UnitPrice = unitPrice;
            Quantity = quantity;
            UserEmail = userEmail;
            FailMessage = failMessage;
        }
    }
}

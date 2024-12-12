using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.IntegrationEvents.Events
{
    public class PaymentSuccessIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public Guid OrderNumber { get; set; }
        public string MenuName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string UserEmail { get; set; }
        public string Address { get; set; }
        public string RestaurantAddress { get; set; }
        public PaymentSuccessIntegrationEvent(Guid userId, Guid restaurantId, Guid branchId, Guid orderNumber, string menuName, decimal unitPrice, int quantity, string userEmail, string address, string restaurantAddress)
        {
            UserId = userId;
            RestaurantId = restaurantId;
            BranchId = branchId;
            OrderNumber = orderNumber;
            MenuName = menuName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            UserEmail = userEmail;
            Address = address;
            RestaurantAddress = restaurantAddress;
        }
    }
}

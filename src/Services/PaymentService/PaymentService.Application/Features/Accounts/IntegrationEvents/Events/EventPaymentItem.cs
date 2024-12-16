using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.IntegrationEvents.Events
{
    public class EventPaymentItem
    {
        public Guid OrderNumber { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public string MenuName { get; set; }
        public string Type { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string UserEmail { get; set; }
        public string Address { get; set; }
        public string RestaurantAddress { get; set; }

        public EventPaymentItem(Guid orderNumber, Guid restaurantId, Guid branchId, string menuName, string type, decimal unitPrice, int quantity, string userEmail, string address, string restaurantAddress)
        {
            OrderNumber = orderNumber;
            RestaurantId = restaurantId;
            BranchId = branchId;
            MenuName = menuName;
            Type = type;
            UnitPrice = unitPrice;
            Quantity = quantity;
            UserEmail = userEmail;
            Address = address;
            RestaurantAddress = restaurantAddress;
        }
    }
}

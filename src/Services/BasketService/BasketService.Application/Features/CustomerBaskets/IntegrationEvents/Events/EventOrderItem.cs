using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.IntegrationEvents.Events
{
    public class EventOrderItem
    {
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public string MenuName { get; set; }
        public string Type { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string UserEmail { get; set; }
        public string Address { get; set; }
        public string RestaurantAddress { get; set; }

        public EventOrderItem(Guid restaurantId, Guid branchId, string menuName, string type, decimal unitPrice, int quantity, string userEmail, string address, string restaurantAddress)
        {
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

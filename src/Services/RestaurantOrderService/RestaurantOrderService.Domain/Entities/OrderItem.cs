using RestaurantOrderService.Domain.Common;
using RestaurantOrderService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Domain.Entities
{
    public class OrderItem : EntityBase
    {
        public Guid OrderNumber { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }
        public string RestaurantAddress { get; set; }
        public string UserEmail { get; set; }
        public string Address { get; set; }
        public string MenuName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }

        public OrderItem()
        {
            
        }

        public OrderItem(Guid orderNumber, Guid restaurantId, Guid branchId, Guid userId, string restaurantAddress, string userEmail, string address, string menuName, decimal unitPrice, int quantity, OrderStatus status)
        {
            OrderNumber = orderNumber;
            RestaurantId = restaurantId;
            BranchId = branchId;
            UserId = userId;
            RestaurantAddress = restaurantAddress;
            UserEmail = userEmail;
            Address = address;
            MenuName = menuName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Status = status;
        }
    }
}

using CourierService.Domain.Common;
using CourierService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Domain.Entites
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
        public OrderStatus OrderStatus { get; set; }
        public Guid? CourierUserId { get; set; }

        public OrderItem()
        {
            
        }

        public OrderItem(Guid orderNumber, Guid restaurantId, Guid branchId, Guid userId, string restaurantAddress, string userEmail,string address, OrderStatus orderStatus, Guid? courierUserId)
        {
            OrderNumber = orderNumber;
            RestaurantId = restaurantId;
            BranchId = branchId;
            UserId = userId;
            RestaurantAddress = restaurantAddress;
            UserEmail = userEmail;
            Address = address;
            OrderStatus = orderStatus;
            CourierUserId = courierUserId;
        }
    }
}

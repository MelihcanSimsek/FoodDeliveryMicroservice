using CourierService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Queries.GetAllPendingOrder
{
    public class GetAllPendingOrderCommandResponse
    {
        public Guid OrderNumber { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public string RestaurantAddress { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}

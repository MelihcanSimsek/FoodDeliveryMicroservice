using CourierService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Queries.GetAllCourierActiveOrders
{
    public class GetAllCourierActiveOrdersQueryResponse
    {
        public Guid OrderNumber { get; set; }
        public string RestaurantAddress { get; set; }
        public string UserEmail { get; set; }
        public string Address { get; set; }
        public string OrderStatus { get; set; }
    }
}

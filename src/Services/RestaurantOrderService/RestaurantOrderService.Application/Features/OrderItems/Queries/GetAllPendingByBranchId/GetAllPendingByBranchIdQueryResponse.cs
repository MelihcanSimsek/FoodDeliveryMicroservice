using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Queries.GetAllPendingByBranchId
{
    public class GetAllPendingByBranchIdQueryResponse
    {
        public Guid OrderNumber { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public string RestaurantAddress { get; set; }
        public string MenuName { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}

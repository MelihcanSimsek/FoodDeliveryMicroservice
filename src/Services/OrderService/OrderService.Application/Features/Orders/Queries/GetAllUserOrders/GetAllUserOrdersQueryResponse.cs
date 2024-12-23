﻿using OrderService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Queries.GetAllUserOrders
{
    public class GetAllUserOrdersQueryResponse
    {
        public Guid OrderNumber { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public string RestaurantAddress { get; set; }
        public string UserEmail { get; set; }
        public string Address { get; set; }
        public string MenuName { get; set; }
        public string Type { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string FailMessage { get; set; }
    }
}

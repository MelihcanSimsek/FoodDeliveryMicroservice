using RestaurantOrderService.Application.Bases;
using RestaurantOrderService.Application.Features.OrderItems.Exceptions;
using RestaurantOrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Rules
{
    public class OrderItemRules : BaseRules
    {
        public async Task ShouldOrderItemExists(OrderItem? orderItem)
        {
            if (orderItem is null) throw new OrderItemNotFoundException();
        }
    }
}

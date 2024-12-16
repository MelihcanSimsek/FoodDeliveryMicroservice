using CourierService.Application.Bases;
using CourierService.Application.Features.OrderItems.Exceptions;
using CourierService.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Rules
{
    public class OrderItemRules : BaseRules
    {

        public async Task ShouldOrderItemExists(OrderItem? orderItem)
        {
            if (orderItem is null) throw new OrderNotExistsException();
        }
    }
}

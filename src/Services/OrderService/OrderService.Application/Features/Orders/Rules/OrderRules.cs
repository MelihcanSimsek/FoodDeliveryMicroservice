using OrderService.Application.Bases;
using OrderService.Application.Features.Orders.Exceptions;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Rules
{
    public class OrderRules : BaseRules
    {
        public async Task ShouldOrderExists(Order? order)
        {
            if (order is null) throw new OrderNotFound();
        }
    }
}

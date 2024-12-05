using OrderService.Application.Exceptions;
using OrderService.Application.Features.Orders.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Exceptions
{
    public class OrderNotFound : BusinessException
    {
        public OrderNotFound() : base(Messages.OrderNotFound)
        {

        }
    }
}

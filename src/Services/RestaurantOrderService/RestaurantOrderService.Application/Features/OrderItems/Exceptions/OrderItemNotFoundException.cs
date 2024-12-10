using RestaurantOrderService.Application.Exceptions;
using RestaurantOrderService.Application.Features.OrderItems.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Exceptions
{
    public class OrderItemNotFoundException : BusinessException
    {
        public OrderItemNotFoundException() : base(Messages.OrderItemNotFound)
        {
            
        }
    }
}

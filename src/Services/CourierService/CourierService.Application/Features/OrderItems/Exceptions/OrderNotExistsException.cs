using CourierService.Application.Exceptions;
using CourierService.Application.Features.OrderItems.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Exceptions
{
    public class OrderNotExistsException : BusinessException
    {
        public OrderNotExistsException() : base(Messages.OrderNotExists)
        {
            
        }
    }
}

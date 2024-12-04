using CourierService.Application.Exceptions;
using CourierService.Application.Features.Couriers.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.Couriers.Exceptions
{
    public class CourierNotExistsException : BusinessException
    {
        public CourierNotExistsException() : base(Messages.CourierNotExists)
        {
            
        }
    }
}

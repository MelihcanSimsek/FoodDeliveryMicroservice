using BasketService.Application.Exceptions;
using BasketService.Application.Features.CustomerBaskets.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Exceptions
{
    public class BasketItemNotFoundException : BusinessException
    {
        public BasketItemNotFoundException() : base(Messages.BasketItemNotFoundWhenStartingOrder)
        {
            
        }
    }
}

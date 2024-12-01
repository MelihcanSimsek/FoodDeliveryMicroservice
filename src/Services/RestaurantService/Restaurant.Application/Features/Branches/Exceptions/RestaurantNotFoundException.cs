using Restaurant.Application.Exceptions;
using Restaurant.Application.Features.Branches.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Branches.Exceptions
{
    public class RestaurantNotFoundException:BusinessException
    {
        public RestaurantNotFoundException():base(Messages.RestaurantNotFound)
        {
            
        }
    }
}

using Menu.Application.Exceptions;
using Menu.Application.Features.Meals.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Meals.Exceptions
{
    public class MealNotFoundException : BusinessException
    {
        public MealNotFoundException() : base(Messages.MealNotFound)
        {
            
        }
    }
}

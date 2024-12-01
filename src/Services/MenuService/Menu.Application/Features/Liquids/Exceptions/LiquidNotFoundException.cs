using Menu.Application.Exceptions;
using Menu.Application.Features.Liquids.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Liquids.Exceptions
{
    public class LiquidNotFoundException : BusinessException
    {
        public LiquidNotFoundException() : base(Messages.LiquidNotFound)
        {
            
        }
    }
}

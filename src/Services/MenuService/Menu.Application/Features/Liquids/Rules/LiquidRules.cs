using Menu.Application.Bases;
using Menu.Application.Features.Liquids.Exceptions;
using Menu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Liquids.Rules
{
    public class LiquidRules : BaseRules
    {

        public async Task ShouldLiquidExists(Liquid? liquid)
        {
            if (liquid is null) throw new LiquidNotFoundException();
        }
    }
}

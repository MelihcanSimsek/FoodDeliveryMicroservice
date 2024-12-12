using BasketService.Application.Bases;
using BasketService.Application.Features.CustomerBaskets.Exceptions;
using BasketService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Rules
{
    public class CustomerBasketRules : BaseRules
    {
        public async Task ShouldBasketItemsExists(IList<BasketItem> items)
        {
            if (items.Count == 0) throw new BasketItemNotFoundException();
        }
    }
}

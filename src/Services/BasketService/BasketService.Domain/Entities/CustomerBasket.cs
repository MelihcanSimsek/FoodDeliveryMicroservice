using BasketService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Domain.Entities
{
    public class CustomerBasket : EntityBase
    {
        public Guid UserId { get; set; }
        public List<BasketItem> BasketItems { get; set; }

        public CustomerBasket()
        {
            this.UserId = Guid.Empty;
            BasketItems = new List<BasketItem>();
        }

        public CustomerBasket(Guid userId, List<BasketItem> basketItems)
        {
            UserId = userId;
            BasketItems = basketItems;
        }
    }
}

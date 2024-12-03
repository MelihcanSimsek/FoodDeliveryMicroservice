using BasketService.Domain.Common;
using BasketService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Domain.Entities
{
    public class BasketItem : EntityBase
    {
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public string MenuName { get; set; }
        public MenuType Type { get; set; } = MenuType.Meal;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public string PictureUrl { get; set; } = string.Empty;

        public BasketItem()
        {
            
        }

        public BasketItem(Guid restaurantId, Guid branchId, string menuName, MenuType type, decimal unitPrice, int quantity, string pictureUrl)
        {
            RestaurantId = restaurantId;
            BranchId = branchId;
            MenuName = menuName;
            Type = type;
            UnitPrice = unitPrice;
            Quantity = quantity;
            PictureUrl = pictureUrl;
        }
    }
}

using MediatR;
using Menu.Application.Interfaces.Authorization;
using Menu.Application.Interfaces.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Meals.Commands.CreateMeal
{
    public class CreateMealCommandRequest : IRequest<Unit>,ISecuredRequest,ICacheRemoverCommand
    {
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? Portion { get; set; }
        public int Gram { get; set; }
        public string[] Roles => ["delivery.owner.restaurant"];
        public string CacheRemoveKey => $"Meal_{RestaurantId}_*";

    }
}

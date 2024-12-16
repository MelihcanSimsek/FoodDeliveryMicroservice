using MediatR;
using Menu.Application.Interfaces.Authorization;
using Menu.Application.Interfaces.RedisCache;
using MongoDB.Bson;

namespace Menu.Application.Features.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommandRequest : IRequest<Unit>, ISecuredRequest, ICacheRemoverCommand
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? Portion { get; set; }
        public int Gram { get; set; }
        public string[] Roles => ["restaurantworker"];
        public string CacheRemoveKey => $"Meal_{RestaurantId}_{BranchId}_*";

    }
}

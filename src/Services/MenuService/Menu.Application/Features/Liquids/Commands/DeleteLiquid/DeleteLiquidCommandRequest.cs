using MongoDB.Bson;
using MediatR;
using Menu.Application.Interfaces.Authorization;
using Menu.Application.Interfaces.RedisCache;

namespace Menu.Application.Features.Liquids.Commands.DeleteLiquid
{
    public class DeleteLiquidCommandRequest : IRequest<Unit>, ISecuredRequest, ICacheRemoverCommand
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public string[] Roles => ["restaurantworker"];
        public string CacheRemoveKey => $"Liquid_{RestaurantId}_{BranchId}_*";

    }
}

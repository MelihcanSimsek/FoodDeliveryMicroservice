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
        public string[] Roles => ["delivery.owner.restaurant"];
        public string CacheRemoveKey => $"Liquid_{RestaurantId}_*";

    }
}

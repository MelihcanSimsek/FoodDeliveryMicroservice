using MediatR;
using Menu.Application.Interfaces.Authorization;
using Menu.Application.Interfaces.RedisCache;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Meals.Commands.DeleteMeal
{
    public class DeleteMealCommandRequest : IRequest<Unit>, ISecuredRequest, ICacheRemoverCommand
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public string[] Roles => ["delivery.owner.restaurant"];

        public string CacheRemoveKey => $"Meal_{RestaurantId}_{BranchId}_*";

    }
}

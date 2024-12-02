using MediatR;
using Menu.Application.Interfaces.Authorization;
using Menu.Application.Interfaces.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Meals.Queries.GetAllMeal
{
    public class GetAllMealQueryRequest : ICachableQuery,ISecuredRequest, IRequest<IList<GetAllMealQueryResponse>>
    {
        public Guid RestaurantId { get; set; }
        public Guid BranchId { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
        public string CacheKey => $"Meal_{RestaurantId}_{BranchId}_Page_{Page}_Size_{Size}";
        public double CacheTime => 30;
        public string[] Roles => ["user"];
    }
}

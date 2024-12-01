using MediatR;
using Menu.Application.Interfaces.Authorization;
using Menu.Application.Interfaces.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Liquids.Queries.GetAllLiquid
{
    public class GetAllLiquidQueryRequest : IRequest<IList<GetAllLiquidQueryResponse>> , ICachableQuery
    {
        public Guid RestaurantId { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
        public string[] roles => ["user"];

        public string CacheKey => $"Liquid_{RestaurantId}_Page_{Page}_Size_{Size}";

        public double CacheTime => 30;
    }
}

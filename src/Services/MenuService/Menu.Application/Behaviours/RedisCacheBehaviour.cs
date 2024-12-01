using MediatR;
using Menu.Application.Interfaces.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Menu.Application.Behaviours
{
    public class RedisCacheBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICachableQuery
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehaviour(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string cacheKey = request.CacheKey;
            double cacheTime = request.CacheTime;

            TResponse value = await redisCacheService.GetAsync<TResponse>(cacheKey);
            if (value is not null)
                return value;

            TResponse response = await next();
            if (response is not null )
                await redisCacheService.SetAsync<TResponse>(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));

            return await next();
        }
    }
}

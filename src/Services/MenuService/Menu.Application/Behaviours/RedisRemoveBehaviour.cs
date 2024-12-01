using MediatR;
using Menu.Application.Interfaces.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Behaviours
{
    public class RedisRemoveBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICacheRemoverCommand
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisRemoveBehaviour(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string cacheRemoveKey = request.CacheRemoveKey;

            if(cacheRemoveKey.Contains("*"))
            {
                await redisCacheService.RemoveByPatternAsync(cacheRemoveKey);
            }
            else
            {
                await redisCacheService.RemoveAsync(cacheRemoveKey);
            }




            return await next();
        }
    }
}

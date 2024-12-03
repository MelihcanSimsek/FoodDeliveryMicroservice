

using BasketService.Application.Interfaces.Repositories;
using BasketService.Domain.Entities;
using BasketService.Persistence.RedisEntity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace BasketService.Persistence.Repositories
{
    public class CustomerBasketRepository : ICustomerBasketRepository
    {
        private readonly ConnectionMultiplexer RedisConnection;
        private readonly IDatabase Database;
        private readonly RedisSettings redisSettings;

        public CustomerBasketRepository(IOptions<RedisSettings> options)
        {
            this.redisSettings = options.Value;
            var opt = ConfigurationOptions.Parse(redisSettings.ConnectionString);
            RedisConnection = ConnectionMultiplexer.Connect(opt);
            Database = RedisConnection.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string userId)
        {
            return await Database.KeyDeleteAsync(userId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string userId)
        {
            var data = await Database.StringGetAsync(userId);

            if (data.IsNullOrEmpty)
            {
                return new CustomerBasket();
            }

            return JsonConvert.DeserializeObject<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(string userId,CustomerBasket basket)
        {
            var created = await Database.StringSetAsync(userId, JsonConvert.SerializeObject(basket));

            return await GetBasketAsync(userId);
        }
    }
}

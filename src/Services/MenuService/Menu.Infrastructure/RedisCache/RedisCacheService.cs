using Menu.Application.Interfaces.RedisCache;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer redisConnection;
        private readonly IDatabase database;
        private readonly RedisSettings redisSettings;

        public RedisCacheService(IOptions<RedisSettings> options)
        {
            redisSettings = options.Value;
            var opt = ConfigurationOptions.Parse(redisSettings.ConnectionString);
            redisConnection = ConnectionMultiplexer.Connect(opt);
            database = redisConnection.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await database.StringGetAsync(key);
            if (value.HasValue)
                return JsonConvert.DeserializeObject<T>(value);
            return default;
        }

        public async Task RemoveAsync(string key)
        {
            await database.KeyDeleteAsync(key);
        }

        public async Task RemoveByPatternAsync(string pattern)
        {
            var server = redisConnection.GetServer(redisConnection.GetEndPoints().First());
            var keys = server.Keys(pattern: pattern);

            foreach (var key in keys)
                await database.KeyDeleteAsync(key);
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            TimeSpan timeUnitExpiration = expirationTime.Value - DateTime.Now;
            await database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUnitExpiration);
        }
    }
}

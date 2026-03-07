using StackExchange.Redis;
using System.Text.Json;
using AddressBookAPI.Services.Logging;

namespace AddressBookAPI.Services.Cache
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IApplicationLogger _logger;

        public RedisService(IConnectionMultiplexer redis, IApplicationLogger logger)
        {
            _redis = redis;
            _logger = logger;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            try
            {
                var db = _redis.GetDatabase();
                var value = await db.StringGetAsync(key);
                
                if (!value.HasValue)
                {
                    _logger.LogInfo($"Cache miss for key: {key}");
                    return default;
                }

                _logger.LogInfo($"Cache hit for key: {key}");
                return JsonSerializer.Deserialize<T>(value.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting cache for key {key}", ex);
                return default;
            }
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            try
            {
                var db = _redis.GetDatabase();
                var serialized = JsonSerializer.Serialize(value);
                
                if (expiry.HasValue)
                {
                    await db.StringSetAsync(key, serialized, expiry.Value);
                }
                else
                {
                    await db.StringSetAsync(key, serialized);
                }
                
                _logger.LogInfo($"Cache set for key: {key}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error setting cache for key {key}", ex);
            }
        }

        public async Task DeleteAsync(string key)
        {
            try
            {
                var db = _redis.GetDatabase();
                await db.KeyDeleteAsync(key);
                _logger.LogInfo($"Cache deleted for key: {key}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting cache for key {key}", ex);
            }
        }

        public async Task<bool> ExistsAsync(string key)
        {
            try
            {
                var db = _redis.GetDatabase();
                return await db.KeyExistsAsync(key);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error checking cache existence for key {key}", ex);
                return false;
            }
        }
    }
}
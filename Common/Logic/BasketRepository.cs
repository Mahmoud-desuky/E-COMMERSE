using System.Text.Json;
using Back.Core.Entities;
using Back.Infrastracture.Interface;
using Back.Common.Interface;
using StackExchange.Redis;


namespace Back.Common.Logic
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string BasketId)
        {
            return await _database.KeyDeleteAsync(BasketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string BasketId)
        {
            var date = await _database.StringGetAsync(BasketId);
            
            return date.IsNullOrEmpty?null:JsonSerializer.Deserialize<CustomerBasket>(date);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (!created)
                return null;
            return await GetBasketAsync(basket.Id);
        }
    }
}
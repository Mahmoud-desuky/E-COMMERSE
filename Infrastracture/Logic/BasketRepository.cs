using System.Text.Json;
using Back.Core.Entities;
using Back.Infrastracture.Interface;
using StackExchange.Redis;

namespace Back.Infrastracture.Logic
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            _database=connectionMultiplexer.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string BasketId)
        {
            return await _database.KeyDeleteAsync(BasketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string BasketId)
        {
            var date =await _database.StringGetAsync(BasketId);
        
            return date.IsNullOrEmpty?null:JsonSerializer.Deserialize<CustomerBasket>(date);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var create=await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));

            if(!create)
                 return null;
           return await GetBasketAsync(basket.Id);

        }
    }
}
using System.Text.Json;
using Back.Core.Entities;
using Back.Infrastracture.Interface;
using Back.Repository.Interface;

namespace Back.Infrastracture.Logic
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IGenaricRepository<CustomerBasket> _basketRepository;
        public BasketRepository(IGenaricRepository<CustomerBasket>basketRepository)
        {
            _basketRepository=basketRepository;
           
        }
        public async Task<bool> DeleteBasketAsync(int BasketId)
        {
            return await _basketRepository.Delete(BasketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(int BasketId)
        {
            var date =await _basketRepository.GetByIdAsync(BasketId);
        
            return date==null?null:date;
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var create=await _basketRepository.Update(basket);

            if(create==null)
                 return null;
           return await GetBasketAsync(basket.Id);

        }
    }
}
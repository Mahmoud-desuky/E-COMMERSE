using Back.Core.Entities;

namespace Back.Infrastracture.Interface
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(int BasketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool>DeleteBasketAsync(int BasketId);

    }
}
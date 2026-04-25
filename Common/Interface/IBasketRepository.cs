using ECommerse.Core.Entities;

namespace ECommerse.Common.Interface
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string BasketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string BasketId);

    }

}
using Back.Core.Entities;

namespace Back.Infrastracture.Interface
{
    public interface IProduct
    {
       Task<Product>  GetByID(long id);
    }
}

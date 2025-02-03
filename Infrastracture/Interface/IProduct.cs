using Back.API.DTOs;
using Back.Core.Entities;

namespace Back.Infrastracture.Interface
{
    public interface IProduct
    {
       Task<ProductDTO>  GetById(int id);
       Task<List<ProductDTO>> GetAll();
    }
}

using Back.Core.Entities;
using Back.Infrastracture.Interface;
using Back.Repository.Interface;

namespace Back.Infrastracture.Logic
{
    public class ProductLogic : IProduct
    {
        private readonly IGenaricRepository<Product> _product;

        public ProductLogic(IGenaricRepository<Product>product)
        {
            _product = product;
        }

        async Task<Product> IProduct.GetByID(long Id)
        {
            try
            {
                return await _product.GetById(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

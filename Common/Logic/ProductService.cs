using ECommerse.Common.Interface;
using ECommerse.Infrastracture.Interface;
using ECommerse.Core.Entities;

namespace ECommerse.Common.Logic
{
    public class ProductService : IProductService
    {
        private readonly IGenaricRepository<Product> _productRepository;
       public ProductService(IGenaricRepository<Product> productRepository)
        {
            _productRepository = productRepository; 
        
       }
         public async Task<Product> CreateProductAsync(Product product)
         {
              return await _productRepository.AddAsync(product);

         }
    }
}
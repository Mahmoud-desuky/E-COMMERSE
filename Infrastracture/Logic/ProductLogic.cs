using AutoMapper;
using Back.API.DTOs;
using Back.Core.Entities;
using Back.Infrastracture.Interface;
using Back.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Back.Infrastracture.Logic
{
    public class ProductLogic : IProduct
    {
        private readonly IGenaricRepository<Product> _product;
        private readonly IMapper _mapper;

        public ProductLogic(IGenaricRepository<Product>product,IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
           var products= await _product.GetAllAsync().Include(x=>x.ProductType) 
                 .Select(x=>new ProductDTO{
                    Id=x.Id,
                    Name=x.Name,
                    Description=x.Description,
                    Price=x.Price,
                    PictureUrl=x.PictureUrl,
                    ProductType=x.ProductType.Name
                }).ToListAsync();
           return products;
        }

        public async Task<ProductDTO> GetById(int id)
        {
             var findProduct= await _product.GetByIdAsync(id);
             if(findProduct==null)
             {
                 throw new  Exception("Product Not Found");
             }
             return _mapper.Map<Product,ProductDTO>(findProduct);
        }

      
    }
}

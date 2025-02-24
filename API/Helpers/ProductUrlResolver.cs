using AutoMapper;
using Back.API.DTOs;
using Back.Core.Entities;

namespace Back.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
            
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}
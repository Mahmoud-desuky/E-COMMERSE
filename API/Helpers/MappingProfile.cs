using AutoMapper;
using ECommerse.Common.DTOs;
using ECommerse.Core.Entities;

namespace ECommerse.API.Helpers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
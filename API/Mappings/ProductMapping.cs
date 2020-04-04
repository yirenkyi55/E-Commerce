using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace API.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {


            CreateMap<Product, ProductToReturnDto>()
                    .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                    .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                    .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());
        }
    }
}
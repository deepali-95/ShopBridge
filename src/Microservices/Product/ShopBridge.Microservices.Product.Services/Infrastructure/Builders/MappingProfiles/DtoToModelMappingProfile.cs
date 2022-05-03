using System;
using AutoMapper;
using ShopBridge.Microservices.Product.Domain;
using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Enums;
using ShopBridge.Microservices.Product.Models.Requests;

namespace ShopBridge.Microservices.Product.Services.Infrastructure.Builders.MappingProfiles
{
    public class DtoToModelMappingProfile : Profile
    {
        public DtoToModelMappingProfile()
        {
            CreateMap<ProductDto, ProductItem>()
                .ForMember(
                    d => d.Status,
                    opt => opt.MapFrom(s => Enum.Parse<ProductStatus>(s.Status.ToString()))
                );
            CreateMap<ProductDto, CreateProductItem>();
            CreateMap<ProductDto, UpdateProductItem>();
        }
    }
}

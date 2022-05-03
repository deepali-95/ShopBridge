using System;
using AutoMapper;
using ShopBridge.Microservices.Product.Domain;
using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Enums;
using ShopBridge.Microservices.Product.Models.Requests;

namespace ShopBridge.Microservices.Product.Services.Infrastructure.Builders.MappingProfiles
{
    public class ModelToDtoMappingProfile : Profile
    {
        public ModelToDtoMappingProfile()
        {
            CreateMap<ProductItem, ProductDto>()
                .ForMember(
                    d => d.Status,
                    opt => opt.MapFrom(s => Enum.Parse<ProductStatus>(s.Status.ToString()))
                );
            CreateMap<CreateProductItem, ProductDto>();
            CreateMap<UpdateProductItem, ProductDto>();
        }
    }
}

using AutoMapper;
using ShopBridge.Microservices.Product.Domain;
using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Requests;
using ShopBridge.Microservices.Product.Services.Infrastructure.Builders.Interfaces;

namespace ShopBridge.Microservices.Product.Services.Infrastructure.Builders
{
    public class ProductBuilder : IProductBuilder
    {
        private readonly IMapper _mapper;

        public ProductBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductItem Build(ProductDto productDto)
        {
            return _mapper.Map<ProductItem>(productDto);
        }

        public ProductDto Build(ProductItem productItem)
        {
            return _mapper.Map<ProductDto>(productItem);
        }

        public ProductDto Build(CreateProductItem productItem)
        {
            return _mapper.Map<ProductDto>(productItem);
        }

        public ProductDto Build(UpdateProductItem productItem)
        {
            return _mapper.Map<ProductDto>(productItem);
        }
    }
}

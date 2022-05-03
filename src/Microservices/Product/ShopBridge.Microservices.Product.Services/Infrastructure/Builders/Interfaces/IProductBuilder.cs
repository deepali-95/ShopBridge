using ShopBridge.Microservices.Product.Domain;
using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Requests;

namespace ShopBridge.Microservices.Product.Services.Infrastructure.Builders.Interfaces
{
    public interface IProductBuilder
    {
        ProductItem Build(ProductDto productDto);
        ProductDto Build(ProductItem productItem);
        ProductDto Build(CreateProductItem productItem);
        ProductDto Build(UpdateProductItem productItem);
    }
}

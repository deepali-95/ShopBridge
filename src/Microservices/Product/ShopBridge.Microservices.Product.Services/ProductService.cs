using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Requests;
using ShopBridge.Microservices.Product.ServiceInterfaces;
using ShopBridge.Microservices.Product.Services.Infrastructure.Handlers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Microservices.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductServiceHandler _productServiceHandler;

        public ProductService(IProductServiceHandler productServiceHandler)
        {
            _productServiceHandler = productServiceHandler;
        }

        public Task<BaseResponse> AddProductAsync(CreateProductItem productItem)
        {
            return _productServiceHandler.HandleAddProductAsync(productItem);
        }

        public Task<BaseResponse> DeleteProductAsync(int productId)
        {
            return _productServiceHandler.HandleDeleteProductAsync(productId);
        }

        public Task<List<ProductItem>> GetAllProductAsync()
        {
            return _productServiceHandler.HandleGetAllProductAsync();
        }

        public Task<ProductItem> GetProductAsync(int productId)
        {
            return _productServiceHandler.HandleGetProductAsync(productId);
        }

        public Task<BaseResponse> UpdateProductAsync(UpdateProductItem productItem)
        {
            return _productServiceHandler.HandleUpdateProductAsync(productItem);
        }
    }
}

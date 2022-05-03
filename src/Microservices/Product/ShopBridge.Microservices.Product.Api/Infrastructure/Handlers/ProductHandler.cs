using ShopBridge.Microservices.Product.Api.Infrastructure.Handlers.Interfaces;
using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Requests;
using ShopBridge.Microservices.Product.ServiceInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Microservices.Product.Api.Infrastructure.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private readonly IProductService _productService;

        public ProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<BaseResponse> AddProductAsync(CreateProductItem productItem)
        {
            return await _productService.AddProductAsync(productItem);
        }

        public async Task<BaseResponse> DeleteProductAsync(int productId)
        {
            return await _productService.DeleteProductAsync(productId);
        }

        public async Task<List<ProductItem>> GetAllProductAsync()
        {
            return await _productService.GetAllProductAsync();
        }

        public async Task<ProductItem> GetProductAsync(int id)
        {
            return await _productService.GetProductAsync(id);
        }

        public async Task<BaseResponse> UpdateProductAsync(UpdateProductItem productItem)
        {
            return await _productService.UpdateProductAsync(productItem);
        }
    }
}

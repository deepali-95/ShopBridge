using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Microservices.Product.Api.Infrastructure.Handlers.Interfaces
{
    public interface IProductHandler
    {
        Task<BaseResponse> AddProductAsync(CreateProductItem productItem);
        Task<BaseResponse> DeleteProductAsync(int productId);
        Task<BaseResponse> UpdateProductAsync(UpdateProductItem productItem);
        Task<List<ProductItem>> GetAllProductAsync();
        Task<ProductItem> GetProductAsync(int productId);
    }
}

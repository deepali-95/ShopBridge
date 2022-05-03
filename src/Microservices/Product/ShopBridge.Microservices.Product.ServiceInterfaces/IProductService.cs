using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Requests;

namespace ShopBridge.Microservices.Product.ServiceInterfaces
{
    public interface IProductService
    {
        Task<BaseResponse> AddProductAsync(CreateProductItem productItem);
        Task<BaseResponse> DeleteProductAsync(int productId);
        Task<BaseResponse> UpdateProductAsync(UpdateProductItem productItem);
        Task<List<ProductItem>> GetAllProductAsync();
        Task<ProductItem> GetProductAsync(int productId);
    }
}

using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Microservices.Product.Services.Infrastructure.Handlers.Interfaces
{
    public interface IProductServiceHandler
    {
        Task<BaseResponse> HandleAddProductAsync(CreateProductItem productItem);
        Task<BaseResponse> HandleDeleteProductAsync(int productId);
        Task<BaseResponse> HandleUpdateProductAsync(UpdateProductItem productItem);
        Task<List<ProductItem>> HandleGetAllProductAsync();
        Task<ProductItem> HandleGetProductAsync(int productId);
    }
}

using ShopBridge.Microservices.Product.Domain;

namespace ShopBridge.Microservices.Product.DataInterfaces
{
    public interface IProductRepository : IRepository<ProductDto>
    {
    }
}

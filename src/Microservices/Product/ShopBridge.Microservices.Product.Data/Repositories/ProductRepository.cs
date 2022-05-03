using Microsoft.Extensions.Logging;
using ShopBridge.Microservices.Product.DataInterfaces;
using ShopBridge.Microservices.Product.Domain;

namespace ShopBridge.Microservices.Product.Data.Repositories
{
    public class ProductRepository : BaseRepository<ProductDto>, IProductRepository
    {
        private readonly ILogger<IProductRepository> _logger;
        public ProductRepository(ILogger<IProductRepository> logger, IDatabaseFactory databaseFactory)
        : base(logger, databaseFactory)
        {
            _logger = logger;
        }
    }
}

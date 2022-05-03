using Dapper.Contrib.Extensions;

namespace ShopBridge.Microservices.Product.Domain
{
    [Table("[Product].[ProductBrand]")]
    public class ProductBrandDto : BaseDto
    {
        [Key]
        public int ProductBrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}

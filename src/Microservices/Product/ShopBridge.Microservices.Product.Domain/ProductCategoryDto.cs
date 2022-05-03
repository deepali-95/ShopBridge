using Dapper.Contrib.Extensions;

namespace ShopBridge.Microservices.Product.Domain
{

    [Table("[Product].[ProductCategory]")]
    public class ProductCategoryDto : BaseDto
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}

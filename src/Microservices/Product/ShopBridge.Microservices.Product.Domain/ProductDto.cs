using Dapper.Contrib.Extensions;

namespace ShopBridge.Microservices.Product.Domain
{
    [Table("[Product].[ProductMaster]")]
    public class ProductDto : BaseDto
    {
        [Key]
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductBrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
    }
}

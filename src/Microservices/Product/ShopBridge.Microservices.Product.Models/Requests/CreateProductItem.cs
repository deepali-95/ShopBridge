namespace ShopBridge.Microservices.Product.Models.Requests
{
    public class CreateProductItem
    {
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

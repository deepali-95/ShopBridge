using System;

namespace ShopBridge.Microservices.Product.Models
{
    public abstract class BaseItem
    {
        public Guid Identifier { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

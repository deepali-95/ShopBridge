using System;

namespace ShopBridge.Microservices.Product.Domain
{
    public abstract class BaseDto
    {
        public BaseDto()
        {
            Identifier = Guid.NewGuid();
        }
        public Guid Identifier { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

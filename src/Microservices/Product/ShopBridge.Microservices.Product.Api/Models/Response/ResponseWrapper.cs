namespace ShopBridge.Microservices.Product.Api.Models.Response
{
    public class ResponseWrapper<T>
    {
        public string Message { get; set; }

        public T Result { get; set; }
    }
}

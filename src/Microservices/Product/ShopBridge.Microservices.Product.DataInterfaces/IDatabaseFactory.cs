using System;
using System.Data;

namespace ShopBridge.Microservices.Product.DataInterfaces
{
    public interface IDatabaseFactory : IDisposable
    {
        IDbConnection Get();
    }
}

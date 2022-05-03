using Microsoft.Extensions.Logging;
using ShopBridge.Microservices.Product.DataInterfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ShopBridge.Microservices.Product.Data
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly ILogger<IDatabaseFactory> _logger;
        private readonly string _connectionString;

        public DatabaseFactory(ILogger<IDatabaseFactory> logger, string connectionString)
        {
            _logger = logger;
            _connectionString = connectionString;
        }

        private IDbConnection _dbContext;

        public IDbConnection Get()
        {
            if (_dbContext == null)
            {
                try
                {
                    _dbContext = new SqlConnection(_connectionString);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _dbContext;
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}

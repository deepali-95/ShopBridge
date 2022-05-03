﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Microservices.Product.DataInterfaces
{
    public interface IRepository<T> where T : class
    {
        long Add(T entity);
        Task<int> AddAsync(T entity);
        long Add(IEnumerable<T> entities);
        Task<long> AddAsync(IEnumerable<T> entities);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        T Get(object id);
        Task<T> GetAsync(object id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
    }
}

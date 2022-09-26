using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> FindById(Guid? id);
        public Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void Edit(T entity);

    }
}

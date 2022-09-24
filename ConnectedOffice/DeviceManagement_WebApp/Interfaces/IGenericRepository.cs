using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //Returns an object with a matching id
        T GetById(int id);
        //Returns all objects in collection
        IEnumerable<T> GetAll();
        //Asynchronously returns all objects in collection
        ValueTask<IEnumerable<T>> GetAllAsync();
        //Finds a specific object in collection
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        //Asynchronously finds a specific object in collection
        ValueTask<T> FindAsync(Guid? id);
        //Asynchornously saves changes to collection
        Task<int> SaveChangesAsync();
        //Adds a new entity to the collection
        void Add(T entity);
        //Adds an array of entities to the collection
        void AddRange(IEnumerable<T> entities);
        //Deletes the entity
        void Remove(T entity);
        //Removes an array of entities from the collection
        void RemoveRange(IEnumerable<T> entities);
        //Updates a specific entity in the collection
        void Update(T entity);
    }
}
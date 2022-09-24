using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;

        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        //Adds a new entity
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        //Adds an array of entities
        public void AddRange(IEnumerable<T> entities) 
        {
            _context.Set<T>().AddRange(entities);
        }
        //Finds a specific object in the collection
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        //Asynchronously finds a specific object in collection
        public ValueTask<T> FindAsync(Guid? id)
        {
            return _context.Set<T>().FindAsync(id);
        }
        //Asynchornously saves changes to collection
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        //Returns all objects in collection
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        //Asynchronously returns all objects in collection
        public async ValueTask<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        //Returns an object with a matching id
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        //Deletes entity
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        //Removes an array of entities from collection
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        //Updates a specific entity in collection
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
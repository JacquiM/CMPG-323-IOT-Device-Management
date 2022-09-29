using DeviceManagement_WebApp.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class //created the GenericRepository class and create the implementation of each method therof which is IGeneric. The GenericRepository will access the DBContext and query the information based on the model you pass through as T – as either category, Devices or Zone
    {
        protected readonly ConnectedOfficeContext _context;
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        public void Add(T entity) // This is the add method that will add data of category or devices or zone to the database
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(Guid? id) // we use the GUID datatype for ID instead of int
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity) // This is the remove method that will remove data from the API or the database
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges(); //Followed by a save changes mechanism 
        }
        public void RemoveRange(IEnumerable<T> entities) //TheremoveRange method it gives a range that can be removed from the API at once 
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges(); // followed by save changes mechanism
        }
        public void Update(T entity) //This is an update method that will update the latest information in the system/ put in the system
        {
            _context.Update(entity);
            _context.SaveChanges(); //followed by a save changes mechanism to save any change 
        }
    }
}

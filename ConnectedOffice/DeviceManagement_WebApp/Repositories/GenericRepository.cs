using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp;

namespace DeviceManagement_WebApp.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;

        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }

        //Adds an entity
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        //Gets all the records
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        //Gets the entity by ID
        public T GetById (int id)
        {
            return _context.Set<T>().Find(id);
        }

        //Removes the record from context
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}

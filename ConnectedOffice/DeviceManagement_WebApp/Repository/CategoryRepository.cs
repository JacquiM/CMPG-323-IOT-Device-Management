using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{

    //Created a Category repository class that i want data from 
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository

    {
        public CategoryRepository(ConnectedOfficeContext context) : base(context) //Created the CategoryRepository class that will inherit ICategoryRepository  
        {
        }
        public bool exists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId   == id);
        }

        public Category GetMostRecentCategory() //then implemented the interface 
        {
            return _context.Category.OrderByDescending(category => category.DateCreated).FirstOrDefault();
        }
    }
}

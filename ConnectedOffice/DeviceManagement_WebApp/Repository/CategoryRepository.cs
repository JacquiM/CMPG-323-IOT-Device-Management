using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.IRepository;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        ConnectedOfficeContext _context;
        public CategoryRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>List of all categories</returns>
        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }
        /// <summary>
        /// Gets A category specified by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Specified ID</returns>
        public Category GetCategoryID(Guid? Id)
        {
            var category = _context.Category
                .FirstOrDefault(m => m.CategoryId == Id);
            return category;
        }
        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>newly created category</returns>
        public Category CreateCategory(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }
        /// <summary>
        /// Updates a category
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="category"></param>
        public void UpdateCategory(Guid Id, Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
        }
        /// <summary>
        /// Removes a specified category
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Category DeleteCategory(Guid? Id)
        {
            var category =GetCategoryID(Id);
            _context.Category.Remove(category);
            _context.SaveChanges();
            return category;
        }
        /// <summary>
        /// Determines if specified category exists
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>true or false</returns>
        public bool CategoryExist(Guid Id)
        {
            return _context.Category.Any(e => e.CategoryId == Id);
        }

    }
}

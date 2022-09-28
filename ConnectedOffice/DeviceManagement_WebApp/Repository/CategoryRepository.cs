using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository
    {
        ConnectedOfficeContext _context = new ConnectedOfficeContext();
        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category GetCategoryID(Guid? Id)
        {
            var category = _context.Category
                .FirstOrDefault(m => m.CategoryId == Id);
            return category;
        }

        public Category CreateCategory(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void UpdateCategory(Guid Id, Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
        }

        public Category DeleteCategory(Guid? Id)
        {
            var category =GetCategoryID(Id);
            _context.Category.Remove(category);
            _context.SaveChanges();
            return category;
        }

        public bool CategoryExist(Guid Id)
        {
            return _context.Category.Any(e => e.CategoryId == Id);
        }

    }
}

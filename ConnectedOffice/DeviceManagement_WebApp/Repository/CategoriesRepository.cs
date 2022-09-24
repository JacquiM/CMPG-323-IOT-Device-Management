using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Interfaces;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(ConnectedOfficeContext context) : base(context)
        {
        }
        public bool Exists(Guid? id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
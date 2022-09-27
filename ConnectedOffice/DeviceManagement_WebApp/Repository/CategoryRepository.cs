using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        // GET: Categories
        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }
    }
}

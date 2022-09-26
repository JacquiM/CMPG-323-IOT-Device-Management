using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.RepoClasses
{
    public class CategoryClass
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        public List<Category> Getall()
        {
            return _context.Category.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository_classes
{
    public class CategoryRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        //GET : Categories
        public List<Category> Getall()
        {
            return _context.Category.ToList();
        }

        // GET : Categories by ID
        public List<Category> GetById()
        {
           
        }
    }
}

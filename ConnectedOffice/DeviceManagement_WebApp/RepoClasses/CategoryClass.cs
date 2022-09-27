using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.RepoClasses
{
    public class CategoryClass
    {
        private readonly ConnectedOfficeContext context = new ConnectedOfficeContext(); 

        public List<Category> Getall()
        {
            return context.Category.ToList();
        }
    }


}

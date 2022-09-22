using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.RepoClasses
{
    public class CategoryClass
    {
        private readonly ConnectedOfficeContext contex = new ConnectedOfficeContext();

        public List<Category> Getall()
        {
           return contex.Category.ToList();
        }

        public List<Category> GetByid(int id)
        {
            return contex.Category.GetByID(id);
        }
    }
}

using DeviceManagement_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DeviceManagement_WebApp.Models;
using System.Linq.Expressions;



public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ConnectedOfficeContext context) : base(context)
    {
    }
  

}



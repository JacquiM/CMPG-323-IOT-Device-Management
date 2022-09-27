using DeviceManagement_WebApp.Models;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetMostRecentCategory();
    }
}


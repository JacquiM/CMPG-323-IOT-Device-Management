using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
// I Created the ICategoryRepository and added the interface definition, 
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        bool exists(Guid id); //Implemented inheritence used GUID Aas datatype
        Category GetMostRecentCategory();
    }
}

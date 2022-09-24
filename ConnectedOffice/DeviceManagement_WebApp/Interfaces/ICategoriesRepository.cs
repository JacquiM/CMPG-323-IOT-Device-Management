using DeviceManagement_WebApp.Models;
using System;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Interfaces
{
    public interface ICategoriesRepository : IGenericRepository<Category>
    {
        bool Exists(Guid? id);
    }
}
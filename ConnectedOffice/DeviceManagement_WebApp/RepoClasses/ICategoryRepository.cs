using DeviceManagement_WebApp.Models;
using System.Linq;

namespace DeviceManagement_WebApp.RepoClasses
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category.GetMostRecentCategory();
    }
}

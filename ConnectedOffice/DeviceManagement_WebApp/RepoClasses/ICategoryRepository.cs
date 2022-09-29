using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.RepositoryClasses
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetMostRecentCategory();

    }
}

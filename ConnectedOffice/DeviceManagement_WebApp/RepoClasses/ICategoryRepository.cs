using DeviceManagement_WebApp.Models;
using static DeviceManagement_WebApp.RepoClasses.IGenericRepository;

namespace DeviceManagement_WebApp.RepositoryClasses
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetMostRecentCategory();

    }
}

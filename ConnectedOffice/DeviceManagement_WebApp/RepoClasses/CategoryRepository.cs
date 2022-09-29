using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.RepoClasses;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DeviceManagement_WebApp.RepositoryClasses
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Category GetMostRecentCategory()
        {
            return _context.Category.OrderByDescending(category => category.CreatedDate).FirstOrDefault();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepo : Controllers
    {
        private readonly ICategoryRepo categoryRepo;
        public CategoriesController(ICategoryRepo categoryRepo)
        {
            _categoryRepository = categoryRepo;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(_categoryRepository.GetAll());
        }

    }
}

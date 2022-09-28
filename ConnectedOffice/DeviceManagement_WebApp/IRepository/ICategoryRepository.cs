using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.IRepository
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Interface for category repository
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetAll();
        Category GetCategoryID(Guid? Id);
        Category CreateCategory(Category category);
        void UpdateCategory(Guid Id, Category category);
        Category DeleteCategory(Guid? Id);
        bool CategoryExist(Guid Id);

    }
}

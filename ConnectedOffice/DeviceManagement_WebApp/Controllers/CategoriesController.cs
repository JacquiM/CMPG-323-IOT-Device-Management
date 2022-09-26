using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _categoryRepository.GetAll());
        }

        // GET: Categories/Details
        public async Task<IActionResult> Details(Guid? id)
        {
            var category = await _categoryRepository.FindById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _categoryRepository.Add(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Edit/
        public async Task<IActionResult> Edit(Guid? id)
        {
            var category = await _categoryRepository.FindById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: Categories/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            try
            {
                _categoryRepository.Edit(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Check if the Id even exists
                if (_categoryRepository.FindById(category.CategoryId) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            var category = await _categoryRepository.FindById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: Categories/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var category = await _categoryRepository.FindById(id);
            if (category == null) return NotFound();
            try
            {
                _categoryRepository.Remove(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_categoryRepository.FindById(category.CategoryId) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

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
using Microsoft.AspNetCore.Authorization;

namespace DeviceManagement_WebApp.Controllers
{
    [Authorize]
    public class DevicesController : Controller
    {
        private readonly IDevicesRepository _devicesRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IZonesRepository _zonesRepository;
        public DevicesController(IDevicesRepository devicesRepository, ICategoriesRepository categoriesRepository, IZonesRepository zonesRepository)
        {
            _devicesRepository = devicesRepository;
            _categoriesRepository = categoriesRepository;
            _zonesRepository = zonesRepository;
        }


        // Retrieves all the device records from DB
        public async Task<IActionResult> Index()
        {
            return View(_devicesRepository.GetAll());
        }

        // Recieve Details of a device record
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _devicesRepository.GetById(id);

            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // Adds new device record to DB
        // GET part of Create(device) 
        public IActionResult Create()
        {


            ViewData["CategoryId"] = new SelectList(_categoriesRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zonesRepository.GetAll(), "ZoneId", "ZoneName");
            return View();

        }

        //POST part of Create(device)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId, DeviceName, CategoryId, ZoneId, Status, IsActive, DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();

            _devicesRepository.Add(device);
            _devicesRepository.Save();



            return RedirectToAction(nameof(Index));
        }

        // Edits a device record on DB
        // GET part of Edit(device)
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _devicesRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoriesRepository.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zonesRepository.GetAll(), "ZoneId", "ZoneName");
            return View(device);
        }

        // POST part of Edit(device)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId, DeviceName, CategoryId, ZoneId, Status, IsActive, DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }

            try
            {
                _devicesRepository.Update(device);
                _devicesRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceId))
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

        // Removes device record from DB
        // GET part of Delete(device)
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _devicesRepository.GetById(id);

            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST part of Delete(device)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var device = _devicesRepository.GetById(id);
            _devicesRepository.Remove(device);
            _devicesRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        // Checks if device record exists
        private bool DeviceExists(Guid id)
        {
            Device device = _devicesRepository.GetById(id);

            if (device != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
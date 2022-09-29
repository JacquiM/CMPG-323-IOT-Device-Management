using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Authorization;

namespace DeviceManagement_WebApp.Controllers
{
    [Authorize]
    public class ZonesController : Controller
    {
        private readonly IZonesRepository _zonesRepository;
        public ZonesController(IZonesRepository zonesRepository)
        {
            _zonesRepository = zonesRepository;
        }


        // Retrieves all the Zone records from DB
        public async Task<IActionResult> Index()
        {
            return View(_zonesRepository.GetAll());
        }

        // Recieve Details of a Zone record
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = _zonesRepository.GetById(id);

            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // Adds new Zone record to DB
        // GET part of Create(Zone)
        public IActionResult Create()
        {
            return View();
        }

        //POST part of Create(Zone)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _zonesRepository.Add(zone);
            _zonesRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        // Edits a Zone record on DB
        // GET part of Edit(Zone)
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = _zonesRepository.GetById(id);
            if (zone == null)
            {
                return NotFound();
            }
            return View(zone);
        }

        // POST part of Edit(Zone)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            if (id != zone.ZoneId)
            {
                return NotFound();
            }

            try
            {
                _zonesRepository.Update(zone);
                _zonesRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(zone.ZoneId))
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

        // Removes Zone record from DB
        // GET part of Delete(Zone)
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = _zonesRepository.GetById(id);

            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // POST part of Delete(Zone)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var zone = _zonesRepository.GetById(id);
            _zonesRepository.Remove(zone);
            _zonesRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        // Checks if Zone record exists
        private bool ZoneExists(Guid id)
        {
            Zone zone = _zonesRepository.GetById(id);

            if (zone != null)
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
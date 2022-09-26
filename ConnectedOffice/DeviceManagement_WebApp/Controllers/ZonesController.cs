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
    public class ZonesController : Controller
    {
        private readonly IZoneRepository _zoneRepository;

        public ZonesController(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        // GET: Zones
        public async Task<IActionResult> Index()
        {
            return View(await _zoneRepository.GetAll());
        }

        // GET: Zones/Details/
        public async Task<IActionResult> Details(Guid? id)
        {
            var zone = await _zoneRepository.FindById(id);
            if (zone == null) return NotFound();
            return View(zone);
        }

        // GET: Zones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            zone.DateCreated = DateTime.Now;
            _zoneRepository.Add(zone);
            return RedirectToAction(nameof(Index));
        }

        // GET: Zones/Edit/
        public async Task<IActionResult> Edit(Guid? id)
        {
            var zone = await _zoneRepository.FindById(id);
            if (zone == null) return NotFound();
            return View(zone);
        }

        // POST: Zones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            if (id != zone.ZoneId)
            {
                return NotFound();
            }

            try
            {
                _zoneRepository.Edit(zone);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_zoneRepository.FindById(zone.ZoneId) == null)
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

        // GET: Zones/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var zone = await _zoneRepository.FindById(id);

            if (zone == null) return NotFound();

            return View(zone);
        }

        // POST: Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var zone = await _zoneRepository.FindById(id);

            if (zone == null) return NotFound();

            try
            {
                _zoneRepository.Remove(zone);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_zoneRepository.FindById(zone.ZoneId) == null)
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

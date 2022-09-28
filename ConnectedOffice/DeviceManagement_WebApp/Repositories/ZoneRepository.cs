using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository_classes
{
    public class ZoneRepository
    {
        // GET: all Zones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zone.ToListAsync());
        }

        // GET: Zones by ID
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // GET: Zones/Create zone
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _context.Add(zone);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Zones/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = await _context.Zone.FindAsync(id);
            if (zone == null)
            {
                return NotFound();
            }
            return View(zone);
        }

        // POST: Zones/Edit by id
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
                _context.Update(zone);
                await _context.SaveChangesAsync();
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

        // GET: Zones/Delete by id
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // POST: Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);
            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }
    }

}
}

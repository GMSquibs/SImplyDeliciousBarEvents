using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimplyDeliciousBarEvents.Data;
using SimplyDeliciousBarEvents.Models;

namespace SimplyDeliciousBarEvents.Controllers
{
    public class LocationModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: LocationModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationModel.ToListAsync());
        }

        [Authorize]
        // GET: LocationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationModel == null)
            {
                return NotFound();
            }

            return View(locationModel);
        }

        [Authorize]
        // GET: LocationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: LocationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LocationName,LocationOwnerFirstName,LocationOwnerLastName,LocationContactNumber")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationModel);
        }

        [Authorize]
        // GET: LocationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel.FindAsync(id);
            if (locationModel == null)
            {
                return NotFound();
            }
            return View(locationModel);
        }

        [Authorize]
        // POST: LocationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocationName,LocationOwnerFirstName,LocationOwnerLastName,LocationContactNumber")] LocationModel locationModel)
        {
            if (id != locationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationModelExists(locationModel.Id))
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
            return View(locationModel);
        }

        [Authorize]
        // GET: LocationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationModel == null)
            {
                return NotFound();
            }

            return View(locationModel);
        }

        [Authorize]
        // POST: LocationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationModel = await _context.LocationModel.FindAsync(id);
            _context.LocationModel.Remove(locationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationModelExists(int id)
        {
            return _context.LocationModel.Any(e => e.Id == id);
        }
    }
}

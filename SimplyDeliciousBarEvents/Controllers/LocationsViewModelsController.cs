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
    public class LocationsViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationsViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: LocationsViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationsViewModel.ToListAsync());
        }

        [Authorize]
        // GET: LocationsViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationsViewModel = await _context.LocationsViewModel
                .FirstOrDefaultAsync(m => m.LocationID == id);
            if (locationsViewModel == null)
            {
                return NotFound();
            }

            return View(locationsViewModel);
        }

        [Authorize]
        // GET: LocationsViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationsViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationID,LocationName,MainContact,ContactNumber,City,State,ZipCode")] LocationsViewModel locationsViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationsViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationsViewModel);
        }

        [Authorize]
        // GET: LocationsViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationsViewModel = await _context.LocationsViewModel.FindAsync(id);
            if (locationsViewModel == null)
            {
                return NotFound();
            }
            return View(locationsViewModel);
        }

        // POST: LocationsViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationID,LocationName,MainContact,ContactNumber,City,State,ZipCode")] LocationsViewModel locationsViewModel)
        {
            if (id != locationsViewModel.LocationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationsViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationsViewModelExists(locationsViewModel.LocationID))
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
            return View(locationsViewModel);
        }

        [Authorize]
        // GET: LocationsViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationsViewModel = await _context.LocationsViewModel
                .FirstOrDefaultAsync(m => m.LocationID == id);
            if (locationsViewModel == null)
            {
                return NotFound();
            }

            return View(locationsViewModel);
        }

        // POST: LocationsViewModels/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationsViewModel = await _context.LocationsViewModel.FindAsync(id);
            _context.LocationsViewModel.Remove(locationsViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationsViewModelExists(int id)
        {
            return _context.LocationsViewModel.Any(e => e.LocationID == id);
        }
    }
}

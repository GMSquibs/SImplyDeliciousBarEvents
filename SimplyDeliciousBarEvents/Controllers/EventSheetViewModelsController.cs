using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimplyDeliciousBarEvents.Data;
using SimplyDeliciousBarEvents.Models;

namespace SimplyDeliciousBarEvents.Controllers
{
    public class EventSheetViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventSheetViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventSheetViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventSheetViewModel.ToListAsync());
        }

        // GET: EventSheetViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSheetViewModel = await _context.EventSheetViewModel
                .FirstOrDefaultAsync(m => m.EventSheetID == id);
            if (eventSheetViewModel == null)
            {
                return NotFound();
            }

            return View(eventSheetViewModel);
        }

        // GET: EventSheetViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventSheetViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventSheetID,Location,EventDate,EventTime,HeadCount,EventCost")] EventSheetViewModel eventSheetViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventSheetViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventSheetViewModel);
        }

        // GET: EventSheetViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSheetViewModel = await _context.EventSheetViewModel.FindAsync(id);
            if (eventSheetViewModel == null)
            {
                return NotFound();
            }
            return View(eventSheetViewModel);
        }

        // POST: EventSheetViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventSheetID,Location,EventDate,EventTime,HeadCount,EventCost")] EventSheetViewModel eventSheetViewModel)
        {
            if (id != eventSheetViewModel.EventSheetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventSheetViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventSheetViewModelExists(eventSheetViewModel.EventSheetID))
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
            return View(eventSheetViewModel);
        }

        // GET: EventSheetViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSheetViewModel = await _context.EventSheetViewModel
                .FirstOrDefaultAsync(m => m.EventSheetID == id);
            if (eventSheetViewModel == null)
            {
                return NotFound();
            }

            return View(eventSheetViewModel);
        }

        // POST: EventSheetViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventSheetViewModel = await _context.EventSheetViewModel.FindAsync(id);
            _context.EventSheetViewModel.Remove(eventSheetViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventSheetViewModelExists(int id)
        {
            return _context.EventSheetViewModel.Any(e => e.EventSheetID == id);
        }
    }
}

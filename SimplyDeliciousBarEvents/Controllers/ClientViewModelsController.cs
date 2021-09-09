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
    public class ClientViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: ClientViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientViewModel.ToListAsync());
        }

        [Authorize]
        // GET: ClientViewModels/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        [Authorize]
        // POST: ClientViewModels/ShowSearchForm
        public async Task<IActionResult> ShowSearchResults(string ContactNumber, string FirstName, string LastName, string Email)
        {
            return View("Index", await _context.ClientViewModel.Where
                (x => x.ContactNumber == ContactNumber && x.FirstName == FirstName && x.LastName == LastName)
                .ToListAsync());
        }

        [Authorize]
        // GET: ClientViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientViewModel = await _context.ClientViewModel
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (clientViewModel == null)
            {
                return NotFound();
            }

            return View(clientViewModel);
        }

        [Authorize]
        // GET: ClientViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientID,ContactNumber,FirstName,LastName,Email,Address,PrimaryOrSecondaryContact")] ClientViewModel clientViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientViewModel);
        }

        [Authorize]
        // GET: ClientViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientViewModel = await _context.ClientViewModel.FindAsync(id);
            if (clientViewModel == null)
            {
                return NotFound();
            }
            return View(clientViewModel);
        }

        // POST: ClientViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientID,ContactNumber,FirstName,LastName,Email,Address,PrimaryOrSecondaryContact")] ClientViewModel clientViewModel)
        {
            if (id != clientViewModel.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientViewModelExists(clientViewModel.ClientID))
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
            return View(clientViewModel);
        }

        [Authorize]
        // GET: ClientViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientViewModel = await _context.ClientViewModel
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (clientViewModel == null)
            {
                return NotFound();
            }

            return View(clientViewModel);
        }

        // POST: ClientViewModels/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientViewModel = await _context.ClientViewModel.FindAsync(id);
            _context.ClientViewModel.Remove(clientViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientViewModelExists(int id)
        {
            return _context.ClientViewModel.Any(e => e.ClientID == id);
        }
    }
}

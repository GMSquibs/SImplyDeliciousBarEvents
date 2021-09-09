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
    public class MenuViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: MenuViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.MenuViewModel.ToListAsync());
        }

        [Authorize]
        // GET: MenuViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuViewModel = await _context.MenuViewModel
                .FirstOrDefaultAsync(m => m.MenuID == id);
            if (menuViewModel == null)
            {
                return NotFound();
            }

            return View(menuViewModel);
        }

        [Authorize]
        // GET: MenuViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuID,BeverageName,Price,Servings")] MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }

        // GET: MenuViewModels/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuViewModel = await _context.MenuViewModel.FindAsync(id);
            if (menuViewModel == null)
            {
                return NotFound();
            }
            return View(menuViewModel);
        }

        // POST: MenuViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuID,BeverageName,Price,Servings")] MenuViewModel menuViewModel)
        {
            if (id != menuViewModel.MenuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuViewModelExists(menuViewModel.MenuID))
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
            return View(menuViewModel);
        }

        [Authorize]
        // GET: MenuViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuViewModel = await _context.MenuViewModel
                .FirstOrDefaultAsync(m => m.MenuID == id);
            if (menuViewModel == null)
            {
                return NotFound();
            }

            return View(menuViewModel);
        }

        // POST: MenuViewModels/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuViewModel = await _context.MenuViewModel.FindAsync(id);
            _context.MenuViewModel.Remove(menuViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuViewModelExists(int id)
        {
            return _context.MenuViewModel.Any(e => e.MenuID == id);
        }
    }
}

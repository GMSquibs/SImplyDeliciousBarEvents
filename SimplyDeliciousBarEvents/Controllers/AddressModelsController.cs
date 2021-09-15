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
    public class AddressModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: AddressModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddressModel.ToListAsync());
        }

        [Authorize]
        // GET: AddressModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressModel = await _context.AddressModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressModel == null)
            {
                return NotFound();
            }

            return View(addressModel);
        }

        [Authorize]
        // GET: AddressModels/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: AddressModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address1,Address2,City,State,Zip")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressModel);
        }

        [Authorize]
        // GET: AddressModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressModel = await _context.AddressModel.FindAsync(id);
            if (addressModel == null)
            {
                return NotFound();
            }
            return View(addressModel);
        }

        [Authorize]
        // POST: AddressModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address1,Address2,City,State,Zip")] AddressModel addressModel)
        {
            if (id != addressModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressModelExists(addressModel.Id))
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
            return View(addressModel);
        }

        [Authorize]
        // GET: AddressModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressModel = await _context.AddressModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressModel == null)
            {
                return NotFound();
            }

            return View(addressModel);
        }

        [Authorize]
        // POST: AddressModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressModel = await _context.AddressModel.FindAsync(id);
            _context.AddressModel.Remove(addressModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressModelExists(int id)
        {
            return _context.AddressModel.Any(e => e.Id == id);
        }
    }
}

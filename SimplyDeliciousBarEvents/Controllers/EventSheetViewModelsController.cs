using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SimplyDeliciousBarEvents.Data;
using SimplyDeliciousBarEvents.Models;

namespace SimplyDeliciousBarEvents.Controllers
{
    public class EventSheetViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        List<EventSheetViewModel> events = new List<EventSheetViewModel>();

        public EventSheetViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }



        [Authorize]
        // GET: EventSheetViewModels
        public async Task<IActionResult> Index()
        {
            GetEventSheetView();
            return View(events);
        }

        public void GetEventSheetView()
        {
            string query = "SELECT * FROM vw_EventSheet";
            using (SqlConnection conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                SqlCommand com = new SqlCommand()
                {
                    CommandText = query,
                    CommandTimeout = 30,
                    Connection = conn
                };                
                using (SqlDataReader rdr = com.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        events.Add(new EventSheetViewModel(
                            rdr["Location"].ToString(),
                            Convert.ToDateTime(rdr["EventDate"].ToString()),
                            TimeSpan.Parse(rdr["EventTime"].ToString()),
                            Convert.ToInt16(rdr["HeadCount"]),
                            float.Parse((rdr["EventCost"]).ToString(), CultureInfo.InvariantCulture.NumberFormat),
                            rdr["Client"].ToString(),
                            rdr["ContactNumber"].ToString(),
                            rdr["Employee"].ToString()
                            )) ;
                    }
                }
            }

            
        }

        [Authorize]
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

        [Authorize]
        // GET: EventSheetViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventSheetViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
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

        [Authorize]
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
        [Authorize]
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

        [Authorize]
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
        [Authorize]
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

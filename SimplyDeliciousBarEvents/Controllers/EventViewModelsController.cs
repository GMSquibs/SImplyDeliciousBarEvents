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
    public class EventViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public List<MenuViewModel> menuItems;
        public List<EmployeeViewModel> employees;

        public EventViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: EventViewModels
        public async Task<IActionResult> Index()
        {
            GetMenuItems();
            GetLocations();
            GetEmployees();
            return View(await _context.EventViewModel.ToListAsync());
        }

        public void GetMenuItems()
        {
            string query = "SELECT * FROM MenuViewModel";
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
                        menuItems.Add(
                            new MenuViewModel
                            (
                                rdr["BeverageName"].ToString(),
                                float.Parse(rdr["Price"].ToString(), CultureInfo.InvariantCulture),
                                Convert.ToInt16(rdr["Servings"].ToString()))
                            );
                    }
                }
            }
        }

        //public void GetLocations()
        //{
        //    string query = "SELECT * FROM LocationsViewModel";
        //    using (SqlConnection conn = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
        //    {
        //        conn.Open();
        //        SqlCommand com = new SqlCommand()
        //        {
        //            CommandText = query,
        //            CommandTimeout = 30,
        //            Connection = conn
        //        };
        //        using (SqlDataReader rdr = com.ExecuteReader())
        //        {
        //            while (rdr.Read())
        //            {
        //                locations.Add(
        //                    new LocationsViewModel(rdr["LocationName"].ToString()));
        //            }
        //        }
        //    }
        //}

        public void GetEmployees()
        {
            string query = "SELECT * FROM EmployeesViewModel";
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
                        employees.Add(
                            new EmployeeViewModel(rdr["FirstName"].ToString(), rdr["LastName"].ToString()));
                    }
                }
            }
        }

        [Authorize]
        // GET: EventViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.EventViewModel
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        [Authorize]
        // GET: EventViewModels/Create
        public IActionResult Create()
        {
            //GetLocations();
            ViewData["LocationName"] = new SelectList(_context.LocationsViewModel, "LocationId", "LocationName");
            return View();
        }

        public IActionResult Locations()
        {
            var model = new LocationsViewModel();
            model.LocationName.ToList();
            return View(model);
        }
        // POST: EventViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,EventDate,EventTime,HeadCount,EventCost,LocationID,")] EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventViewModel);
        }

        [Authorize]
        // GET: EventViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.EventViewModel.FindAsync(id);
            if (eventViewModel == null)
            {
                return NotFound();
            }
            return View(eventViewModel);
        }

        // POST: EventViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,EventDate,EventTime,HeadCount,EventCost")] EventViewModel eventViewModel)
        {
            if (id != eventViewModel.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventViewModelExists(eventViewModel.EventID))
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
            return View(eventViewModel);
        }

        // GET: EventViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = await _context.EventViewModel
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        // POST: EventViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventViewModel = await _context.EventViewModel.FindAsync(id);
            _context.EventViewModel.Remove(eventViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventViewModelExists(int id)
        {
            return _context.EventViewModel.Any(e => e.EventID == id);
        }
    }
}

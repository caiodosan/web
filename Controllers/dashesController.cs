#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using dashboard.Data;

namespace dashboard.Controllers
{
    public class dashesController : Controller
    {
        private readonly dashboardContext _context;

        public dashesController(dashboardContext context)
        {
            _context = context;
        }
        

        // GET: dashes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: dashes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dash = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dash == null)
            {
                return NotFound();
            }

            return View(dash);
        }

        // GET: dashes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: dashes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] dash dash)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dash);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dash);
        }

        // GET: dashes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dash = await _context.Movie.FindAsync(id);
            if (dash == null)
            {
                return NotFound();
            }
            return View(dash);
        }

        // POST: dashes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] dash dash)
        {
            if (id != dash.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dash);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dashExists(dash.Id))
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
            return View(dash);
        }

        // GET: dashes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dash = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dash == null)
            {
                return NotFound();
            }

            return View(dash);
        }

        // POST: dashes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dash = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(dash);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dashExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcStockings.Data;
using MvcStockings.Models;

namespace MvcStockings.Controllers
{
    public class StockingsController : Controller
    {
        private readonly MvcStockingsContext _context;

        public StockingsController(MvcStockingsContext context)
        {
            _context = context;
        }

        // GET: Stockings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stocking.ToListAsync());
        }

        // GET: Stockings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocking = await _context.Stocking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stocking == null)
            {
                return NotFound();
            }

            return View(stocking);
        }

        // GET: Stockings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stockings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Material,Price,Review")] Stocking stocking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stocking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stocking);
        }

        // GET: Stockings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocking = await _context.Stocking.FindAsync(id);
            if (stocking == null)
            {
                return NotFound();
            }
            return View(stocking);
        }

        // POST: Stockings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Material,Price,Review")] Stocking stocking)
        {
            if (id != stocking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stocking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockingExists(stocking.Id))
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
            return View(stocking);
        }

        // GET: Stockings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocking = await _context.Stocking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stocking == null)
            {
                return NotFound();
            }

            return View(stocking);
        }

        // POST: Stockings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stocking = await _context.Stocking.FindAsync(id);
            _context.Stocking.Remove(stocking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockingExists(int id)
        {
            return _context.Stocking.Any(e => e.Id == id);
        }
    }
}

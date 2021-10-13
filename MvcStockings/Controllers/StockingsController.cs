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
        public async Task<IActionResult> Index(string StockingType, string search)
        {
            //Creates the query to select the different stockings based on the filter
            IQueryable<string> typeQuery = from t in _context.Stocking
                                           orderby t.Type
                                           select t.Type;

            //Creates the query to search for the stocking with a name equal to the search
            var stockings = from s in _context.Stocking
                            select s;

            //Checks to make sure the search is not empty
            if (!String.IsNullOrEmpty(search))
            {
                //inserts the name field into the query to check for matches
                stockings = stockings.Where(q => q.Name.Contains(search));
            }

            //Checks if stocking type is empty in the filter
            if (!string.IsNullOrEmpty(StockingType))
            {
                //If the filter is not empty then it will match all stockings with the type in the filter and display them
                stockings = stockings.Where(x => x.Type == StockingType);
            }

            //Creates the different lists based on the filter / search method
            var stockingTypeVM = new StockingTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Stockings = await stockings.ToListAsync()
            };

            //returns the new list of stockings after the search or filter
            return View(stockingTypeVM);
            
            
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

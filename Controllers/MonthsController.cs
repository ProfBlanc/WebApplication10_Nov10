using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication10_Nov10.Data;
using WebApplication10_Nov10.Models;

namespace WebApplication10_Nov10.Controllers
{
    public class MonthsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonthsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Months
        public async Task<IActionResult> Index()
        {
            return View(await _context.Months.ToListAsync());
        }

        // GET: Months/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthModel = await _context.Months
                .FirstOrDefaultAsync(m => m.MonthId == id);
            if (monthModel == null)
            {
                return NotFound();
            }

            return View(monthModel);
        }

        // GET: Months/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Months/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MonthId,MonthName")] MonthModel monthModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monthModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monthModel);
        }

        // GET: Months/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthModel = await _context.Months.FindAsync(id);
            if (monthModel == null)
            {
                return NotFound();
            }
            return View(monthModel);
        }

        // POST: Months/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MonthId,MonthName")] MonthModel monthModel)
        {
            if (id != monthModel.MonthId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monthModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthModelExists(monthModel.MonthId))
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
            return View(monthModel);
        }

        // GET: Months/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthModel = await _context.Months
                .FirstOrDefaultAsync(m => m.MonthId == id);
            if (monthModel == null)
            {
                return NotFound();
            }

            return View(monthModel);
        }

        // POST: Months/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthModel = await _context.Months.FindAsync(id);
            if (monthModel != null)
            {
                _context.Months.Remove(monthModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthModelExists(int id)
        {
            return _context.Months.Any(e => e.MonthId == id);
        }
    }
}

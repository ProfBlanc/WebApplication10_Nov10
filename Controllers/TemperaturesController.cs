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
    public class TemperaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TemperaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Temperatures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Temperatures.Include(t => t.Month);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Temperatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatureModel = await _context.Temperatures
                .Include(t => t.Month)
                .FirstOrDefaultAsync(m => m.TemperatureId == id);
            if (temperatureModel == null)
            {
                return NotFound();
            }

            return View(temperatureModel);
        }

        // GET: Temperatures/Create
        public IActionResult Create()
        {
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthName");
            return View();
        }

        // POST: Temperatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TemperatureId,MonthId")] TemperatureModel temperatureModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperatureModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthName", temperatureModel.MonthId);
            return View(temperatureModel);
        }

        // GET: Temperatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatureModel = await _context.Temperatures.FindAsync(id);
            if (temperatureModel == null)
            {
                return NotFound();
            }
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthName", temperatureModel.MonthId);
            return View(temperatureModel);
        }

        // POST: Temperatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TemperatureId,MonthId")] TemperatureModel temperatureModel)
        {
            if (id != temperatureModel.TemperatureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperatureModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperatureModelExists(temperatureModel.TemperatureId))
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
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "MonthName", temperatureModel.MonthId);
            return View(temperatureModel);
        }

        // GET: Temperatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatureModel = await _context.Temperatures
                .Include(t => t.Month)
                .FirstOrDefaultAsync(m => m.TemperatureId == id);
            if (temperatureModel == null)
            {
                return NotFound();
            }

            return View(temperatureModel);
        }

        // POST: Temperatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temperatureModel = await _context.Temperatures.FindAsync(id);
            if (temperatureModel != null)
            {
                _context.Temperatures.Remove(temperatureModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperatureModelExists(int id)
        {
            return _context.Temperatures.Any(e => e.TemperatureId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dietcore.Data;
using Dietcore.Models;

namespace Dietcore.Controllers
{
    public class DietitiansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DietitiansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dietitians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dietitian.ToListAsync());
        }

        // GET: Dietitians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietitian = await _context.Dietitian
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dietitian == null)
            {
                return NotFound();
            }

            return View(dietitian);
        }

        // GET: Dietitians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dietitians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,EnrollmentDate")] Dietitian dietitian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dietitian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dietitian);
        }

        // GET: Dietitians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietitian = await _context.Dietitian.FindAsync(id);
            if (dietitian == null)
            {
                return NotFound();
            }
            return View(dietitian);
        }

        // POST: Dietitians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstMidName,EnrollmentDate")] Dietitian dietitian)
        {
            if (id != dietitian.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dietitian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietitianExists(dietitian.ID))
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
            return View(dietitian);
        }

        // GET: Dietitians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietitian = await _context.Dietitian
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dietitian == null)
            {
                return NotFound();
            }

            return View(dietitian);
        }

        // POST: Dietitians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietitian = await _context.Dietitian.FindAsync(id);
            _context.Dietitian.Remove(dietitian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietitianExists(int id)
        {
            return _context.Dietitian.Any(e => e.ID == id);
        }
    }
}

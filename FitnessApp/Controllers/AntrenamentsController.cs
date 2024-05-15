using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Models;

namespace FitnessApp.Controllers
{
    public class AntrenamentsController : Controller
    {
        private readonly ApplicationContext _context;

        public AntrenamentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Antrenaments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Antrenament.ToListAsync());
        }

        // GET: Antrenaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenament = await _context.Antrenament
                .FirstOrDefaultAsync(m => m.ID_Antrenament == id);
            if (antrenament == null)
            {
                return NotFound();
            }

            return View(antrenament);
        }

        // GET: Antrenaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Antrenaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Antrenament,ID_Istoric,Antrenament_Descriere")] Antrenament antrenament)
        {
            
            {
                _context.Add(antrenament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antrenament);
        }

        // GET: Antrenaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenament = await _context.Antrenament.FindAsync(id);
            if (antrenament == null)
            {
                return NotFound();
            }
            return View(antrenament);
        }

        // POST: Antrenaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Antrenament,ID_Istoric,Antrenament_Descriere")] Antrenament antrenament)
        {
            if (id != antrenament.ID_Antrenament)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(antrenament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntrenamentExists(antrenament.ID_Antrenament))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            return View(antrenament);
        }

        // GET: Antrenaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antrenament = await _context.Antrenament
                .FirstOrDefaultAsync(m => m.ID_Antrenament == id);
            if (antrenament == null)
            {
                return NotFound();
            }

            return View(antrenament);
        }

        // POST: Antrenaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antrenament = await _context.Antrenament.FindAsync(id);
            if (antrenament != null)
            {
                _context.Antrenament.Remove(antrenament);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntrenamentExists(int id)
        {
            return _context.Antrenament.Any(e => e.ID_Antrenament == id);
        }
    }
}

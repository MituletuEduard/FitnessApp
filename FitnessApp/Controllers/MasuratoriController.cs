using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers
{
    public class MasuratoriController : Controller
    {
        private readonly IMasuratoriService _service;

        public MasuratoriController(IMasuratoriService service)
        {
            _service = service;
        }

        // GET: Masuratori
        public async Task<IActionResult> Index()
        {
            var masuratori = await _service.GetAllMasuratori();
            return View(masuratori);
        }

        // GET: Masuratori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masuratori = await _service.GetMasuratoriById(id.Value);
            if (masuratori == null)
            {
                return NotFound();
            }

            return View(masuratori);
        }

        // GET: Masuratori/Create
        public IActionResult Create()
        {
            ViewData["ID_Utilizator"] = new SelectList(_service.GetUtilizatori(), "ID_Utilizator", "ID_Utilizator");
            return View();
        }

        // POST: Masuratori/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Masuratori,Greutate,ID_Utilizator")] Masuratori masuratori)
        {
            if (ModelState.IsValid)
            {
                await _service.AddMasuratori(masuratori);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Utilizator"] = new SelectList(_service.GetUtilizatori(), "ID_Utilizator", "ID_Utilizator", masuratori.ID_Utilizator);
            return View(masuratori);
        }

        // GET: Masuratori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masuratori = await _service.GetMasuratoriById(id.Value);
            if (masuratori == null)
            {
                return NotFound();
            }
            ViewData["ID_Utilizator"] = new SelectList(_service.GetUtilizatori(), "ID_Utilizator", "ID_Utilizator", masuratori.ID_Utilizator);
            return View(masuratori);
        }

        // POST: Masuratori/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Masuratori,Greutate,ID_Utilizator")] Masuratori masuratori)
        {
            if (id != masuratori.ID_Masuratori)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateMasuratori(masuratori);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.MasuratoriExists(masuratori.ID_Masuratori))
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
            ViewData["ID_Utilizator"] = new SelectList(_service.GetUtilizatori(), "ID_Utilizator", "ID_Utilizator", masuratori.ID_Utilizator);
            return View(masuratori);
        }

        // GET: Masuratori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masuratori = await _service.GetMasuratoriById(id.Value);
            if (masuratori == null)
            {
                return NotFound();
            }

            return View(masuratori);
        }

        // POST: Masuratori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteMasuratori(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

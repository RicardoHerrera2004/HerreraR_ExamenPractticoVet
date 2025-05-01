using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HerreraR_ExamenPractticoVet.Models;

namespace HerreraR_ExamenPractticoVet.Controllers
{
    public class VisitaController : Controller
    {
        private readonly SQLExamenPractticoVetContext _context;

        public VisitaController(SQLExamenPractticoVetContext context)
        {
            _context = context;
        }

        // GET: Visita
        public async Task<IActionResult> Index()
        {
            var sQLExamenPractticoVetContext = _context.Visita.Include(v => v.Mascota);
            return View(await sQLExamenPractticoVetContext.ToListAsync());
        }

        // GET: Visita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visita
                .Include(v => v.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // GET: Visita/Create
        public IActionResult Create()
        {
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Especie");
            return View();
        }

        // POST: Visita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaVisita,Motivo,Observaciones,RequiereMedicacion,MascotaId")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Especie", visita.MascotaId);
            return View(visita);
        }

        // GET: Visita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visita.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Especie", visita.MascotaId);
            return View(visita);
        }

        // POST: Visita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaVisita,Motivo,Observaciones,RequiereMedicacion,MascotaId")] Visita visita)
        {
            if (id != visita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaExists(visita.Id))
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
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Especie", visita.MascotaId);
            return View(visita);
        }

        // GET: Visita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visita
                .Include(v => v.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // POST: Visita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visita = await _context.Visita.FindAsync(id);
            if (visita != null)
            {
                _context.Visita.Remove(visita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaExists(int id)
        {
            return _context.Visita.Any(e => e.Id == id);
        }
    }
}

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
    public class PropietarioController : Controller
    {
        private readonly SQLExamenPractticoVetContext _context;

        public PropietarioController(SQLExamenPractticoVetContext context)
        {
            _context = context;
        }

        // GET: Propietario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Propietario.ToListAsync());
        }

        // GET: Propietario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // GET: Propietario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propietario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,FechaNacimiento,FechaCreacion,EsClienteFrecuente")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propietario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }

        // GET: Propietario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietario.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }
            return View(propietario);
        }

        // POST: Propietario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,FechaNacimiento,FechaCreacion,EsClienteFrecuente")] Propietario propietario)
        {
            if (id != propietario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propietario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropietarioExists(propietario.Id))
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
            return View(propietario);
        }

        // GET: Propietario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // POST: Propietario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propietario = await _context.Propietario.FindAsync(id);
            if (propietario != null)
            {
                _context.Propietario.Remove(propietario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropietarioExists(int id)
        {
            return _context.Propietario.Any(e => e.Id == id);
        }
    }
}

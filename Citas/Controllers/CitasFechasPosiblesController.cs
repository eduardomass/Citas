using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Citas.Datos;
using Citas.Models;

namespace Citas.Controllers
{
    public class CitasFechasPosiblesController : Controller
    {
        private readonly BaseDeDatos _context;

        public CitasFechasPosiblesController(BaseDeDatos context)
        {
            _context = context;
        }

        // GET: CitasFechasPosibles
        public async Task<IActionResult> Index()
        {
            var baseDeDatos = _context.CitasFechasPosibles.Include(c => c.Cita);
            return View(await baseDeDatos.ToListAsync());
        }

        // GET: CitasFechasPosibles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaFechaPosible = await _context.CitasFechasPosibles
                .Include(c => c.Cita)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citaFechaPosible == null)
            {
                return NotFound();
            }

            return View(citaFechaPosible);
        }

        // GET: CitasFechasPosibles/Create
        public IActionResult Create()
        {
            ViewData["CitaId"] = new SelectList(_context.Citas, "Id", "Id");
            return View();
        }

        // POST: CitasFechasPosibles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,CitaId")] CitaFechaPosible citaFechaPosible)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citaFechaPosible);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CitaId"] = new SelectList(_context.Citas, "Id", "Id", citaFechaPosible.CitaId);
            return View(citaFechaPosible);
        }

        // GET: CitasFechasPosibles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaFechaPosible = await _context.CitasFechasPosibles.FindAsync(id);
            if (citaFechaPosible == null)
            {
                return NotFound();
            }
            ViewData["CitaId"] = new SelectList(_context.Citas, "Id", "Id", citaFechaPosible.CitaId);
            return View(citaFechaPosible);
        }

        // POST: CitasFechasPosibles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,CitaId")] CitaFechaPosible citaFechaPosible)
        {
            if (id != citaFechaPosible.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citaFechaPosible);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaFechaPosibleExists(citaFechaPosible.Id))
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
            ViewData["CitaId"] = new SelectList(_context.Citas, "Id", "Id", citaFechaPosible.CitaId);
            return View(citaFechaPosible);
        }

        // GET: CitasFechasPosibles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaFechaPosible = await _context.CitasFechasPosibles
                .Include(c => c.Cita)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citaFechaPosible == null)
            {
                return NotFound();
            }

            return View(citaFechaPosible);
        }

        // POST: CitasFechasPosibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citaFechaPosible = await _context.CitasFechasPosibles.FindAsync(id);
            _context.CitasFechasPosibles.Remove(citaFechaPosible);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaFechaPosibleExists(int id)
        {
            return _context.CitasFechasPosibles.Any(e => e.Id == id);
        }
    }
}

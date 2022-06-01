using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Citas.Datos;
using Citas.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading;

namespace Citas.Controllers
{
    [Authorize]
    public class CitasController : ControladorBase
    {
        private readonly BaseDeDatos _context;

        public CitasController(BaseDeDatos context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            int idUsuario = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            string rol = User.FindFirstValue(ClaimTypes.Role);
            if (rol.Equals("ADMIN"))
            {
                var baseDeDatosDeUsuario = _context
                .Citas
                .Include(c => c.Categoria)
                .Include(c => c.Usuario);
                return View(await baseDeDatosDeUsuario.ToListAsync());
            }
            else
            {
                var baseDeDatosDeUsuario = _context
                .Citas
                .Where(o => o.UsuarioId == idUsuario)
                .Include(c => c.Categoria)
                .Include(c => c.Usuario);
                return View(await baseDeDatosDeUsuario.ToListAsync());
            }
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.Categoria)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion");
            if (this.EsAdmin)
            {
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre");
            }
            else
            {
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios.Where(o=>o.Id == IdUsuario).ToList(), "Id", "Nombre");
            }
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fechacreacion,CategoriaId,UsuarioId")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", cita.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", cita.UsuarioId);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context
                .Citas
                .Include(c=> c.CitasFechasPosibles)
                .Where(o=>o.Id == id)
                .FirstOrDefaultAsync();

            if (cita == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", cita.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nombre", cita.UsuarioId);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fechacreacion,CategoriaId,UsuarioId")] Cita cita)
        {
            if (id != cita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", cita.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", cita.UsuarioId);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.Categoria)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Citas.Any(e => e.Id == id);
        }

        [HttpPost, ActionName("AddDate")]
        public IActionResult AddDate(int id, DateTime fecha)
        {
            if (id > 0)
            {
                try
                {
                    _context.CitasFechasPosibles.Add(new CitaFechaPosible()
                    {
                        CitaId = id,
                        Fecha = fecha
                    });
                    _context.SaveChanges();
                    return Ok();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            else
            {
                throw new Exception("El Id de cita esta mal...");
            }
            //return Json(new { success = false, responseText = "The attached file is not supported." });
            //return Ok();
        }


        [HttpPost, ActionName("DeleteDate")]
        public IActionResult DeleteDate(int id)
        {
            if (id > 0)
            {
                try
                {
                    var entidadAEliminar = _context.CitasFechasPosibles.FirstOrDefault(o => o.Id == id);
                    _context
                        .CitasFechasPosibles
                        .Remove(entidadAEliminar);
                        
                    _context.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            else
            {
                throw new Exception("El Id de cita esta mal...");
            }
            //return Json(new { success = false, responseText = "The attached file is not supported." });
            //return Ok();
        }
    }
}

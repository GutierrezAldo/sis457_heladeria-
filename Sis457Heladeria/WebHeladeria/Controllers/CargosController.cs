using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHeladeria.Models;

namespace WebHeladeria.Controllers
{
    public class CargosController : Controller
    {
        private readonly FinalHeladeriaContext _context;

        public CargosController(FinalHeladeriaContext context)
        {
            _context = context;
        }

        // GET: Cargoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cargos.ToListAsync());
        }

        // GET: Cargos/Listar (AJAX)
        [HttpGet]
        public async Task<JsonResult> Listar()
        {
            var list = await _context.Cargos
                .Select(c => new { Id = c.Id, Nombre = c.Descripcion })
                .ToListAsync();
            return Json(list);
        }

        // POST: Cargos/CreateAjax (AJAX)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateAjax(string Nombre)
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                return Json(new { success = false, mensaje = "El nombre es requerido." });
            }

            var cargo = new Cargo
            {
                Descripcion = Nombre.Trim(),
                FechaRegistro = DateTime.Now,
                UsuarioRegistro = User.Identity?.Name ?? "Sistema",
                Estado = 1
            };

            _context.Add(cargo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, mensaje = "Cargo agregado exitosamente.", id = cargo.Id });
        }

        // POST: Cargos/Eliminar (AJAX)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Eliminar(int id)
        {
            var tieneEmpleados = await _context.Empleados.AnyAsync(e => e.IdCargo == id);
            if (tieneEmpleados)
            {
                return Json(new { success = false, mensaje = "No se puede eliminar el cargo porque tiene empleados asociados." });
            }

            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null)
            {
                return Json(new { success = false, mensaje = "Cargo no encontrado." });
            }

            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();
            return Json(new { success = true, mensaje = "Cargo eliminado correctamente." });
        }

        // GET: Cargos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // GET: Cargos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descripcion")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                cargo.FechaRegistro = DateTime.Now;
                cargo.UsuarioRegistro = User.Identity?.Name ?? "Sistema";
                cargo.Estado = 1;
                _context.Add(cargo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cargo);
        }

        // GET: Cargoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }

        // POST: Cargoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existente = await _context.Cargos.FindAsync(id);
                    if (existente == null) return NotFound();

                    existente.Descripcion = cargo.Descripcion;
                    // conservar UsuarioRegistro/FechaRegistro

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(cargo.Id))
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
            return View(cargo);
        }

        // GET: Cargos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo != null)
            {
                _context.Cargos.Remove(cargo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoExists(int id)
        {
            return _context.Cargos.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHeladeria.Models;

namespace WebHeladeria.Controllers
{
    [Authorize] 
    public class EmpleadosController : Controller
    {
        private readonly FinalHeladeriaContext _context;

        public EmpleadosController(FinalHeladeriaContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var finalHeladeriaContext = _context.Empleados.Include(e => e.IdCargoNavigation);
            return View(await finalHeladeriaContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdCargoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "Id", "Descripcion");
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado empleado)
        {
            // Limpiar espacios en blanco
            if(!string.IsNullOrWhiteSpace(empleado.Nombres))
            {
                empleado.Nombres = empleado.Nombres.Trim();
            }
            if(!string.IsNullOrWhiteSpace(empleado.PrimerApellido))
            {
                empleado.PrimerApellido = empleado.PrimerApellido.Trim();
            }
            if(!string.IsNullOrWhiteSpace(empleado.SegundoApellido))
            {
                empleado.SegundoApellido = empleado.SegundoApellido.Trim();
            }
            if(!string.IsNullOrWhiteSpace(empleado.Telefono))
            {
                empleado.Telefono = empleado.Telefono.Trim();
            }
            if(!string.IsNullOrWhiteSpace(empleado.Direccion))
            {
                empleado.Direccion = empleado.Direccion.Trim();
            }

            // CRÍTICO: Remover campos de auditoría del ModelState ANTES de validar
            ModelState.Remove("UsuarioRegistro");
            ModelState.Remove("FechaRegistro");
            ModelState.Remove("Estado");
            ModelState.Remove("IdCargoNavigation");

            // Validar el modelo después de remover campos de auditoría
            if (ModelState.IsValid)
            {
                try
                {
                    // Asignar campos de auditoría por el servidor
                    empleado.FechaRegistro = DateTime.Now;
                    empleado.UsuarioRegistro = User.Identity?.Name ?? "Sistema";
                    empleado.Estado = 1;

                    _context.Add(empleado);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Empleado registrado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Error al guardar el empleado: " + ex.InnerException?.Message);
                }
            }
            
            // Si falla la validación, recargar SelectList con el valor seleccionado
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "Id", "Descripcion", empleado.IdCargo);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "Id", "Descripcion", empleado.IdCargo);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            // Limpiar espacios en blanco
            if(!string.IsNullOrWhiteSpace(empleado.Nombres))
            {
                empleado.Nombres = empleado.Nombres.Trim();
            }
            if(!string.IsNullOrWhiteSpace(empleado.PrimerApellido))
            {
                empleado.PrimerApellido = empleado.PrimerApellido.Trim();
            }
            if(!string.IsNullOrWhiteSpace(empleado.SegundoApellido))
            {
                empleado.SegundoApellido = empleado.SegundoApellido.Trim();
            }
            if(!string.IsNullOrWhiteSpace(empleado.Telefono))
            {
                empleado.Telefono = empleado.Telefono.Trim();
            }
            if(!string.IsNullOrWhiteSpace(empleado.Direccion))
            {
                empleado.Direccion = empleado.Direccion.Trim();
            }

            // Remover campos de auditoría del ModelState
            ModelState.Remove("UsuarioRegistro");
            ModelState.Remove("FechaRegistro");
            ModelState.Remove("Estado");
            ModelState.Remove("IdCargoNavigation");

            if (ModelState.IsValid)
            {
                try
                {
                    // Evitar sobre-posting: cargar la entidad existente y actualizar solo campos permitidos
                    var existente = await _context.Empleados.FindAsync(id);
                    if (existente == null)
                    {
                        return NotFound();
                    }

                    // Actualizar solo los campos editables
                    existente.Nombres = empleado.Nombres;
                    existente.PrimerApellido = empleado.PrimerApellido;
                    existente.SegundoApellido = empleado.SegundoApellido;
                    existente.Telefono = empleado.Telefono;
                    existente.Direccion = empleado.Direccion;
                    existente.IdCargo = empleado.IdCargo;

                    // No modificar UsuarioRegistro/FechaRegistro para preservar auditoría

                    _context.Update(existente);
                    await _context.SaveChangesAsync();
                    TempData["Mensaje"] = "Empleado editado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Error al actualizar el empleado: " + ex.InnerException?.Message);
                }
            }
            
            // Si falla la validación, recargar SelectList con el valor seleccionado
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "Id", "Descripcion", empleado.IdCargo);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdCargoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado != null)
            {
                // Comprobar si existen usuarios asociados (dependencia)
                bool tieneUsuarios = await _context.Usuarios.AnyAsync(u => u.IdEmpleado == id);

                if (tieneUsuarios)
                {
                    TempData["Error"] = "No se puede eliminar el empleado porque tiene usuarios asociados en el sistema.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Empleado eliminado exitosamente.";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
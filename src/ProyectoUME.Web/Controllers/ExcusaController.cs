using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoUME.Core.Domain;
using ProyectoUME.Infrastructure.Data;

namespace ProyectoUME.Web.Controllers
{
    public class ExcusaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExcusaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Excusa
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Excusa.Include(e => e.IdUsuariosNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Excusa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusa = await _context.Excusa
                .Include(e => e.IdUsuariosNavigation)
                .FirstOrDefaultAsync(m => m.IdExcusa == id);
            if (excusa == null)
            {
                return NotFound();
            }

            return View(excusa);
        }

        // GET: Excusa/Create
        public IActionResult Create()
        {
            ViewData["IdUsuarios"] = new SelectList(_context.Usuario, "IdUsuario", "PrimerApellido");
            return View();
        }

        // POST: Excusa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExcusa,AnexoEvidencia,Nombre1,Nombre2,Apellido1,Apellodo2,Correo,Telefono,IdUsuarios")] Excusa excusa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excusa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuarios"] = new SelectList(_context.Usuario, "IdUsuario", "PrimerApellido", excusa.IdUsuarios);
            return View(excusa);
        }

        // GET: Excusa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusa = await _context.Excusa.FindAsync(id);
            if (excusa == null)
            {
                return NotFound();
            }
            ViewData["IdUsuarios"] = new SelectList(_context.Usuario, "IdUsuario", "PrimerApellido", excusa.IdUsuarios);
            return View(excusa);
        }

        // POST: Excusa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExcusa,AnexoEvidencia,Nombre1,Nombre2,Apellido1,Apellodo2,Correo,Telefono,IdUsuarios")] Excusa excusa)
        {
            if (id != excusa.IdExcusa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excusa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcusaExists(excusa.IdExcusa))
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
            ViewData["IdUsuarios"] = new SelectList(_context.Usuario, "IdUsuario", "PrimerApellido", excusa.IdUsuarios);
            return View(excusa);
        }

        // GET: Excusa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excusa = await _context.Excusa
                .Include(e => e.IdUsuariosNavigation)
                .FirstOrDefaultAsync(m => m.IdExcusa == id);
            if (excusa == null)
            {
                return NotFound();
            }

            return View(excusa);
        }

        // POST: Excusa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excusa = await _context.Excusa.FindAsync(id);
            _context.Excusa.Remove(excusa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcusaExists(int id)
        {
            return _context.Excusa.Any(e => e.IdExcusa == id);
        }
    }
}

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
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Usuario.Include(u => u.Aspnetusers).Include(u => u.EmpresaNitNavigation).Include(u => u.IdProyectoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Aspnetusers)
                .Include(u => u.EmpresaNitNavigation)
                .Include(u => u.IdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Id");
            ViewData["EmpresaNit"] = new SelectList(_context.Empresa, "Nit", "Ciudad");
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "DireccionPoyecto");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Cedula,Edad,Telefono,Jornada,IdProyecto,EmpresaNit,AspnetusersId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Id", usuario.AspnetusersId);
            ViewData["EmpresaNit"] = new SelectList(_context.Empresa, "Nit", "Ciudad", usuario.EmpresaNit);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "DireccionPoyecto", usuario.IdProyecto);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Id", usuario.AspnetusersId);
            ViewData["EmpresaNit"] = new SelectList(_context.Empresa, "Nit", "Ciudad", usuario.EmpresaNit);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "DireccionPoyecto", usuario.IdProyecto);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Cedula,Edad,Telefono,Jornada,IdProyecto,EmpresaNit,AspnetusersId")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Id", usuario.AspnetusersId);
            ViewData["EmpresaNit"] = new SelectList(_context.Empresa, "Nit", "Ciudad", usuario.EmpresaNit);
            ViewData["IdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "DireccionPoyecto", usuario.IdProyecto);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Aspnetusers)
                .Include(u => u.EmpresaNitNavigation)
                .Include(u => u.IdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}

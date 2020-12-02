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
    public class ListaEmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaEmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ListaEmpleados
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListaEmpleados.Include(l => l.ProyectoIdProyectoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListaEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaEmpleados = await _context.ListaEmpleados
                .Include(l => l.ProyectoIdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdListaEmpleados == id);
            if (listaEmpleados == null)
            {
                return NotFound();
            }

            return View(listaEmpleados);
        }

        // GET: ListaEmpleados/Create
        public IActionResult Create()
        {
            ViewData["ProyectoIdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "DireccionPoyecto");
            return View();
        }

        // POST: ListaEmpleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdListaEmpleados,ProyectoIdProyecto")] ListaEmpleados listaEmpleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaEmpleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProyectoIdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "DireccionPoyecto", listaEmpleados.ProyectoIdProyecto);
            return View(listaEmpleados);
        }

        // GET: ListaEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaEmpleados = await _context.ListaEmpleados.FindAsync(id);
            if (listaEmpleados == null)
            {
                return NotFound();
            }
            ViewData["ProyectoIdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "DireccionPoyecto", listaEmpleados.ProyectoIdProyecto);
            return View(listaEmpleados);
        }

        // POST: ListaEmpleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdListaEmpleados,ProyectoIdProyecto")] ListaEmpleados listaEmpleados)
        {
            if (id != listaEmpleados.IdListaEmpleados)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaEmpleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaEmpleadosExists(listaEmpleados.IdListaEmpleados))
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
            ViewData["ProyectoIdProyecto"] = new SelectList(_context.Proyecto, "IdProyecto", "DireccionPoyecto", listaEmpleados.ProyectoIdProyecto);
            return View(listaEmpleados);
        }

        // GET: ListaEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaEmpleados = await _context.ListaEmpleados
                .Include(l => l.ProyectoIdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdListaEmpleados == id);
            if (listaEmpleados == null)
            {
                return NotFound();
            }

            return View(listaEmpleados);
        }

        // POST: ListaEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaEmpleados = await _context.ListaEmpleados.FindAsync(id);
            _context.ListaEmpleados.Remove(listaEmpleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaEmpleadosExists(int id)
        {
            return _context.ListaEmpleados.Any(e => e.IdListaEmpleados == id);
        }
    }
}

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
    public class TurnoLaboralController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurnoLaboralController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TurnoLaboral
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TurnoLaboral.Include(t => t.JornadaIdJornadaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TurnoLaboral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoLaboral = await _context.TurnoLaboral
                .Include(t => t.JornadaIdJornadaNavigation)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (turnoLaboral == null)
            {
                return NotFound();
            }

            return View(turnoLaboral);
        }

        // GET: TurnoLaboral/Create
        public IActionResult Create()
        {
            ViewData["JornadaIdJornada"] = new SelectList(_context.Jornada, "IdJornada", "IdJornada");
            return View();
        }

        // POST: TurnoLaboral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,HoraIngreso,HoraSalida,JornadaIdJornada")] TurnoLaboral turnoLaboral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turnoLaboral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JornadaIdJornada"] = new SelectList(_context.Jornada, "IdJornada", "IdJornada", turnoLaboral.JornadaIdJornada);
            return View(turnoLaboral);
        }

        // GET: TurnoLaboral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoLaboral = await _context.TurnoLaboral.FindAsync(id);
            if (turnoLaboral == null)
            {
                return NotFound();
            }
            ViewData["JornadaIdJornada"] = new SelectList(_context.Jornada, "IdJornada", "IdJornada", turnoLaboral.JornadaIdJornada);
            return View(turnoLaboral);
        }

        // POST: TurnoLaboral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,HoraIngreso,HoraSalida,JornadaIdJornada")] TurnoLaboral turnoLaboral)
        {
            if (id != turnoLaboral.IdConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turnoLaboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoLaboralExists(turnoLaboral.IdConsulta))
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
            ViewData["JornadaIdJornada"] = new SelectList(_context.Jornada, "IdJornada", "IdJornada", turnoLaboral.JornadaIdJornada);
            return View(turnoLaboral);
        }

        // GET: TurnoLaboral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnoLaboral = await _context.TurnoLaboral
                .Include(t => t.JornadaIdJornadaNavigation)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (turnoLaboral == null)
            {
                return NotFound();
            }

            return View(turnoLaboral);
        }

        // POST: TurnoLaboral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turnoLaboral = await _context.TurnoLaboral.FindAsync(id);
            _context.TurnoLaboral.Remove(turnoLaboral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoLaboralExists(int id)
        {
            return _context.TurnoLaboral.Any(e => e.IdConsulta == id);
        }
    }
}

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
    public class DocumentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Documento
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Documentos.Include(d => d.IdTramiteNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Documento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentos = await _context.Documentos
                .Include(d => d.IdTramiteNavigation)
                .FirstOrDefaultAsync(m => m.IdTramite == id);
            if (documentos == null)
            {
                return NotFound();
            }

            return View(documentos);
        }

        // GET: Documento/Create
        public IActionResult Create()
        {
            ViewData["IdTramite"] = new SelectList(_context.Usuario, "IdUsuario", "Correo");
            return View();
        }

        // POST: Documento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTramite,CursoAlturas,CertificadoEps,CertificadoArl,CertificadoPension,HojaVida")] Documentos documentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTramite"] = new SelectList(_context.Usuario, "IdUsuario", "Correo", documentos.IdTramite);
            return View(documentos);
        }

        // GET: Documento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentos = await _context.Documentos.FindAsync(id);
            if (documentos == null)
            {
                return NotFound();
            }
            ViewData["IdTramite"] = new SelectList(_context.Usuario, "IdUsuario", "Correo", documentos.IdTramite);
            return View(documentos);
        }

        // POST: Documento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTramite,CursoAlturas,CertificadoEps,CertificadoArl,CertificadoPension,HojaVida")] Documentos documentos)
        {
            if (id != documentos.IdTramite)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentosExists(documentos.IdTramite))
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
            ViewData["IdTramite"] = new SelectList(_context.Usuario, "IdUsuario", "Correo", documentos.IdTramite);
            return View(documentos);
        }

        // GET: Documento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentos = await _context.Documentos
                .Include(d => d.IdTramiteNavigation)
                .FirstOrDefaultAsync(m => m.IdTramite == id);
            if (documentos == null)
            {
                return NotFound();
            }

            return View(documentos);
        }

        // POST: Documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentos = await _context.Documentos.FindAsync(id);
            _context.Documentos.Remove(documentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentosExists(int id)
        {
            return _context.Documentos.Any(e => e.IdTramite == id);
        }
    }
}

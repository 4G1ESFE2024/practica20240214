using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica20240214.Models;

namespace Practica20240214.Controllers
{
    public class RopasController : Controller
    {
        private readonly Practica20240214DBContext _context;

        public RopasController(Practica20240214DBContext context)
        {
            _context = context;
        }

        // GET: Ropas
        public async Task<IActionResult> Index()
        {
            var practica20240214DBContext = _context.Ropas.Include(r => r.IdTallaNavigation);
            return View(await practica20240214DBContext.ToListAsync());
        }

        // GET: Ropas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ropas == null)
            {
                return NotFound();
            }

            var ropa = await _context.Ropas
                .Include(r => r.IdTallaNavigation)
                .FirstOrDefaultAsync(m => m.IdRopa == id);
            if (ropa == null)
            {
                return NotFound();
            }

            return View(ropa);
        }

        // GET: Ropas/Create
        public IActionResult Create()
        {
            ViewData["IdTalla"] = new SelectList(_context.Tallas, "IdTalla", "NombreTalla");
            return View();
        }

        // POST: Ropas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRopa,NombreRopa,TipoRopa,IdTalla")] Ropa ropa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ropa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTalla"] = new SelectList(_context.Tallas, "IdTalla", "NombreTalla", ropa.IdTalla);
            return View(ropa);
        }

        // GET: Ropas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ropas == null)
            {
                return NotFound();
            }

            var ropa = await _context.Ropas.FindAsync(id);
            if (ropa == null)
            {
                return NotFound();
            }
            ViewData["IdTalla"] = new SelectList(_context.Tallas, "IdTalla", "NombreTalla", ropa.IdTalla);
            return View(ropa);
        }

        // POST: Ropas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRopa,NombreRopa,TipoRopa,IdTalla")] Ropa ropa)
        {
            if (id != ropa.IdRopa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ropa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RopaExists(ropa.IdRopa))
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
            ViewData["IdTalla"] = new SelectList(_context.Tallas, "IdTalla", "NombreTalla", ropa.IdTalla);
            return View(ropa);
        }

        // GET: Ropas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ropas == null)
            {
                return NotFound();
            }

            var ropa = await _context.Ropas
                .Include(r => r.IdTallaNavigation)
                .FirstOrDefaultAsync(m => m.IdRopa == id);
            if (ropa == null)
            {
                return NotFound();
            }

            return View(ropa);
        }

        // POST: Ropas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ropas == null)
            {
                return Problem("Entity set 'Practica20240214DBContext.Ropas'  is null.");
            }
            var ropa = await _context.Ropas.FindAsync(id);
            if (ropa != null)
            {
                _context.Ropas.Remove(ropa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RopaExists(int id)
        {
          return (_context.Ropas?.Any(e => e.IdRopa == id)).GetValueOrDefault();
        }
    }
}

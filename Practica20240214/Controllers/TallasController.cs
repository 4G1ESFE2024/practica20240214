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
    public class TallasController : Controller
    {
        private readonly Practica20240214DBContext _context;

        public TallasController(Practica20240214DBContext context)
        {
            _context = context;
        }

        // GET: Tallas
        public async Task<IActionResult> Index()
        {
              return _context.Tallas != null ? 
                          View(await _context.Tallas.ToListAsync()) :
                          Problem("Entity set 'Practica20240214DBContext.Tallas'  is null.");
        }

        // GET: Tallas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tallas == null)
            {
                return NotFound();
            }

            var talla = await _context.Tallas
                .FirstOrDefaultAsync(m => m.IdTalla == id);
            if (talla == null)
            {
                return NotFound();
            }

            return View(talla);
        }

        // GET: Tallas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tallas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTalla,NombreTalla")] Talla talla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(talla);
        }

        // GET: Tallas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tallas == null)
            {
                return NotFound();
            }

            var talla = await _context.Tallas.FindAsync(id);
            if (talla == null)
            {
                return NotFound();
            }
            return View(talla);
        }

        // POST: Tallas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTalla,NombreTalla")] Talla talla)
        {
            if (id != talla.IdTalla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TallaExists(talla.IdTalla))
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
            return View(talla);
        }

        // GET: Tallas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tallas == null)
            {
                return NotFound();
            }

            var talla = await _context.Tallas
                .FirstOrDefaultAsync(m => m.IdTalla == id);
            if (talla == null)
            {
                return NotFound();
            }

            return View(talla);
        }

        // POST: Tallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tallas == null)
            {
                return Problem("Entity set 'Practica20240214DBContext.Tallas'  is null.");
            }
            var talla = await _context.Tallas.FindAsync(id);
            if (talla != null)
            {
                _context.Tallas.Remove(talla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TallaExists(int id)
        {
          return (_context.Tallas?.Any(e => e.IdTalla == id)).GetValueOrDefault();
        }
    }
}

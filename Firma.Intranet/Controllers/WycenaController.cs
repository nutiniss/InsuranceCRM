 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data.Ubezpieczenia;

namespace Firma.Intranet.Controllers
{
    public class WycenaController : Controller
    {
        private readonly FirmaContext _context;

        public WycenaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Wycena
        public async Task<IActionResult> Index()
        {
            var firmaContext = _context.Wycena.Include(w => w.Oferta);
            return View(await firmaContext.ToListAsync());
        }

        // GET: Wycena/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycena = await _context.Wycena
                .Include(w => w.Oferta)
                .FirstOrDefaultAsync(m => m.IdWyceny == id);
            if (wycena == null)
            {
                return NotFound();
            }

            return View(wycena);
        }

        // GET: Wycena/Create
        public IActionResult Create()
        {
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty");
            return View();
        }

        // POST: Wycena/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWyceny,DataWyceny,MetodaWyceny,WartoscPrzedmiotuUbezpieczenia,SumaUbezpieczenia,Skladka,Uwagi,IdOferty")] Wycena wycena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wycena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty", wycena.IdOferty);
            return View(wycena);
        }

        // GET: Wycena/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycena = await _context.Wycena.FindAsync(id);
            if (wycena == null)
            {
                return NotFound();
            }
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty", wycena.IdOferty);
            return View(wycena);
        }

        // POST: Wycena/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWyceny,DataWyceny,MetodaWyceny,WartoscPrzedmiotuUbezpieczenia,SumaUbezpieczenia,Skladka,Uwagi,IdOferty")] Wycena wycena)
        {
            if (id != wycena.IdWyceny)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wycena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WycenaExists(wycena.IdWyceny))
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
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty", wycena.IdOferty);
            return View(wycena);
        }

        // GET: Wycena/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wycena = await _context.Wycena
                .Include(w => w.Oferta)
                .FirstOrDefaultAsync(m => m.IdWyceny == id);
            if (wycena == null)
            {
                return NotFound();
            }

            return View(wycena);
        }

        // POST: Wycena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wycena = await _context.Wycena.FindAsync(id);
            if (wycena != null)
            {
                _context.Wycena.Remove(wycena);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WycenaExists(int id)
        {
            return _context.Wycena.Any(e => e.IdWyceny == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.Ubezpieczenia;

namespace Firma.Intranet.Controllers
{
    public class OfertaController : Controller
    {
        private readonly FirmaContext _context;

        public OfertaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Oferta
        public async Task<IActionResult> Index()
        {
            var firmaContext = _context.Oferta.Include(o => o.Klient).Include(o => o.ProduktUbezpieczeniowy).Include(o => o.Uzytkownik);
            return View(await firmaContext.ToListAsync());
        }

        // GET: Oferta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferta
                .Include(o => o.Klient)
                .Include(o => o.ProduktUbezpieczeniowy)
                .Include(o => o.Uzytkownik)
                .FirstOrDefaultAsync(m => m.IdOferty == id);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        // GET: Oferta/Create
        public IActionResult Create()
        {
            ViewData["IdKlienta"] = new SelectList(_context.Set<Klient>(), "IdKlienta", "Email");
            ViewData["IdProduktuUbezpieczeniowego"] = new SelectList(_context.Set<ProduktUbezpieczeniowy>(), "IdProduktuUbezpieczeniowego", "Kategoria");
            ViewData["IdUzytkownika"] = new SelectList(_context.Set<Uzytkownik>(), "IdUzytkownika", "Email");
            return View();
        }

        // POST: Oferta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOferty,NumerOferty,DataUtworzenia,DataWaznosci,Status,Przypis,IdKlienta,IdUzytkownika,IdProduktuUbezpieczeniowego")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oferta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlienta"] = new SelectList(_context.Set<Klient>(), "IdKlienta", "Email", oferta.IdKlienta);
            ViewData["IdProduktuUbezpieczeniowego"] = new SelectList(_context.Set<ProduktUbezpieczeniowy>(), "IdProduktuUbezpieczeniowego", "Kategoria", oferta.IdProduktuUbezpieczeniowego);
            ViewData["IdUzytkownika"] = new SelectList(_context.Set<Uzytkownik>(), "IdUzytkownika", "Email", oferta.IdUzytkownika);
            return View(oferta);
        }

        // GET: Oferta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferta.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }
            ViewData["IdKlienta"] = new SelectList(_context.Set<Klient>(), "IdKlienta", "Email", oferta.IdKlienta);
            ViewData["IdProduktuUbezpieczeniowego"] = new SelectList(_context.Set<ProduktUbezpieczeniowy>(), "IdProduktuUbezpieczeniowego", "Kategoria", oferta.IdProduktuUbezpieczeniowego);
            ViewData["IdUzytkownika"] = new SelectList(_context.Set<Uzytkownik>(), "IdUzytkownika", "Email", oferta.IdUzytkownika);
            return View(oferta);
        }

        // POST: Oferta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOferty,NumerOferty,DataUtworzenia,DataWaznosci,Status,Przypis,IdKlienta,IdUzytkownika,IdProduktuUbezpieczeniowego")] Oferta oferta)
        {
            if (id != oferta.IdOferty)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oferta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertaExists(oferta.IdOferty))
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
            ViewData["IdKlienta"] = new SelectList(_context.Set<Klient>(), "IdKlienta", "Email", oferta.IdKlienta);
            ViewData["IdProduktuUbezpieczeniowego"] = new SelectList(_context.Set<ProduktUbezpieczeniowy>(), "IdProduktuUbezpieczeniowego", "Kategoria", oferta.IdProduktuUbezpieczeniowego);
            ViewData["IdUzytkownika"] = new SelectList(_context.Set<Uzytkownik>(), "IdUzytkownika", "Email", oferta.IdUzytkownika);
            return View(oferta);
        }

        // GET: Oferta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferta
                .Include(o => o.Klient)
                .Include(o => o.ProduktUbezpieczeniowy)
                .Include(o => o.Uzytkownik)
                .FirstOrDefaultAsync(m => m.IdOferty == id);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        // POST: Oferta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oferta = await _context.Oferta.FindAsync(id);
            if (oferta != null)
            {
                _context.Oferta.Remove(oferta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertaExists(int id)
        {
            return _context.Oferta.Any(e => e.IdOferty == id);
        }
    }
}

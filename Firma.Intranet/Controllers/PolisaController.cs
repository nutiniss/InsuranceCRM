using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.Ubezpieczenia;
using Firma.Intranet.Infrastructure;

namespace Firma.Intranet.Controllers
{
    public class PolisaController : Controller
    {
        private readonly FirmaContext _context;

        public PolisaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Polisa
        public async Task<IActionResult> Index()
        {
            var firmaContext = _context.Polisa.Include(p => p.Klient).Include(p => p.Oferta).Include(p => p.ProduktUbezpieczeniowy).Include(p => p.Uzytkownik);
            return View(await firmaContext.ToListAsync());
        }

        // GET: Polisa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polisa = await _context.Polisa
                .Include(p => p.Klient)
                .Include(p => p.Oferta)
                .Include(p => p.ProduktUbezpieczeniowy)
                .Include(p => p.Uzytkownik)
                .FirstOrDefaultAsync(m => m.IdPolisy == id);
            if (polisa == null)
            {
                return NotFound();
            }

            await this.LoadSlownikAsync(_context, "StatusyPolisy", TypSlownika.StatusPolisy, polisa.Status);
            return View(polisa);
        }

        // GET: Polisa/Create
        public async Task<IActionResult> Create()
        {

            await this.LoadSlownikAsync(_context, "StatusyPolisy", TypSlownika.StatusPolisy);
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email");
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty");
            ViewData["IdProduktuUbezpieczeniowego"] = new SelectList(_context.ProduktUbezpieczeniowy, "IdProduktuUbezpieczeniowego", "Kategoria");
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email");
            return View();
        }

        // POST: Polisa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPolisy,NumerPolisy,PoczatekOchrony,KoniecOchrony,Skladka,Status,IdKlienta,IdUzytkownika,IdProduktuUbezpieczeniowego,IdOferty")] Polisa polisa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(polisa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", polisa.IdKlienta);
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty", polisa.IdOferty);
            ViewData["IdProduktuUbezpieczeniowego"] = new SelectList(_context.ProduktUbezpieczeniowy, "IdProduktuUbezpieczeniowego", "Kategoria", polisa.IdProduktuUbezpieczeniowego);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", polisa.IdUzytkownika);
            await this.LoadSlownikAsync(_context, "StatusyPolisy", TypSlownika.StatusPolisy, polisa.Status);
            return View(polisa);
        }

        // GET: Polisa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polisa = await _context.Polisa.FindAsync(id);
            if (polisa == null)
            {
                return NotFound();
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", polisa.IdKlienta);
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty", polisa.IdOferty);
            ViewData["IdProduktuUbezpieczeniowego"] = new SelectList(_context.ProduktUbezpieczeniowy, "IdProduktuUbezpieczeniowego", "Kategoria", polisa.IdProduktuUbezpieczeniowego);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", polisa.IdUzytkownika);
            await this.LoadSlownikAsync(_context, "StatusyPolisy", TypSlownika.StatusPolisy, polisa.Status);
            return View(polisa);
        }

        // POST: Polisa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPolisy,NumerPolisy,PoczatekOchrony,KoniecOchrony,Skladka,Status,IdKlienta,IdUzytkownika,IdProduktuUbezpieczeniowego,IdOferty")] Polisa polisa)
        {
            if (id != polisa.IdPolisy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(polisa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolisaExists(polisa.IdPolisy))
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
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", polisa.IdKlienta);
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty", polisa.IdOferty);
            ViewData["IdProduktuUbezpieczeniowego"] = new SelectList(_context.ProduktUbezpieczeniowy, "IdProduktuUbezpieczeniowego", "Kategoria", polisa.IdProduktuUbezpieczeniowego);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", polisa.IdUzytkownika);
            await this.LoadSlownikAsync(_context, "StatusyPolisy", TypSlownika.StatusPolisy, polisa.Status);
            return View(polisa);
        }

        // GET: Polisa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polisa = await _context.Polisa
                .Include(p => p.Klient)
                .Include(p => p.Oferta)
                .Include(p => p.ProduktUbezpieczeniowy)
                .Include(p => p.Uzytkownik)
                .FirstOrDefaultAsync(m => m.IdPolisy == id);
            if (polisa == null)
            {
                return NotFound();
            }

            await this.LoadSlownikAsync(_context, "StatusyPolisy", TypSlownika.StatusPolisy, polisa.Status);
            return View(polisa);
        }

        // POST: Polisa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var polisa = await _context.Polisa.FindAsync(id);
            if (polisa != null)
            {
                polisa.MarkAsDeleted();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolisaExists(int id)
        {
            return _context.Polisa.Any(e => e.IdPolisy == id);
        }
    }
}

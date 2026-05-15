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
    public class OfertaMarketingowaController : Controller
    {
        private readonly FirmaContext _context;

        public OfertaMarketingowaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: OfertaMarketingowa
        public async Task<IActionResult> Index()
        {
            var firmaContext = _context.OfertaMarketingowa.Include(o => o.Uzytkownik);
            return View(await firmaContext.ToListAsync());
        }

        // GET: OfertaMarketingowa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaMarketingowa = await _context.OfertaMarketingowa
                .Include(o => o.Uzytkownik)
                .FirstOrDefaultAsync(m => m.IdOfertyMarketingowej == id);
            if (ofertaMarketingowa == null)
            {
                return NotFound();
            }

            await this.LoadSlownikAsync(_context, "GrupyDocelowe", TypSlownika.GrupaDocelowa, ofertaMarketingowa.GrupaDocelowa);
            return View(ofertaMarketingowa);
        }

        // GET: OfertaMarketingowa/Create
        public async Task<IActionResult> Create()
        {

            await this.LoadSlownikAsync(_context, "GrupyDocelowe", TypSlownika.GrupaDocelowa);
            ViewData["IdUzytkownika"] = new SelectList(_context.Set<Uzytkownik>(), "IdUzytkownika", "Email");
            return View();
        }

        // POST: OfertaMarketingowa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOfertyMarketingowej,Tytul,Tresc,GrupaDocelowa,DataUtworzenia,DataPublikacji,DataWaznosci,CzyAktywna,IdUzytkownika")] OfertaMarketingowa ofertaMarketingowa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ofertaMarketingowa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUzytkownika"] = new SelectList(_context.Set<Uzytkownik>(), "IdUzytkownika", "Email", ofertaMarketingowa.IdUzytkownika);
            await this.LoadSlownikAsync(_context, "GrupyDocelowe", TypSlownika.GrupaDocelowa, ofertaMarketingowa.GrupaDocelowa);
            return View(ofertaMarketingowa);
        }

        // GET: OfertaMarketingowa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaMarketingowa = await _context.OfertaMarketingowa.FindAsync(id);
            if (ofertaMarketingowa == null)
            {
                return NotFound();
            }
            ViewData["IdUzytkownika"] = new SelectList(_context.Set<Uzytkownik>(), "IdUzytkownika", "Email", ofertaMarketingowa.IdUzytkownika);
            await this.LoadSlownikAsync(_context, "GrupyDocelowe", TypSlownika.GrupaDocelowa, ofertaMarketingowa.GrupaDocelowa);
            return View(ofertaMarketingowa);
        }

        // POST: OfertaMarketingowa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOfertyMarketingowej,Tytul,Tresc,GrupaDocelowa,DataUtworzenia,DataPublikacji,DataWaznosci,CzyAktywna,IdUzytkownika")] OfertaMarketingowa ofertaMarketingowa)
        {
            if (id != ofertaMarketingowa.IdOfertyMarketingowej)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ofertaMarketingowa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertaMarketingowaExists(ofertaMarketingowa.IdOfertyMarketingowej))
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
            ViewData["IdUzytkownika"] = new SelectList(_context.Set<Uzytkownik>(), "IdUzytkownika", "Email", ofertaMarketingowa.IdUzytkownika);
            await this.LoadSlownikAsync(_context, "GrupyDocelowe", TypSlownika.GrupaDocelowa, ofertaMarketingowa.GrupaDocelowa);
            return View(ofertaMarketingowa);
        }

        // GET: OfertaMarketingowa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaMarketingowa = await _context.OfertaMarketingowa
                .Include(o => o.Uzytkownik)
                .FirstOrDefaultAsync(m => m.IdOfertyMarketingowej == id);
            if (ofertaMarketingowa == null)
            {
                return NotFound();
            }

            await this.LoadSlownikAsync(_context, "GrupyDocelowe", TypSlownika.GrupaDocelowa, ofertaMarketingowa.GrupaDocelowa);
            return View(ofertaMarketingowa);
        }

        // POST: OfertaMarketingowa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ofertaMarketingowa = await _context.OfertaMarketingowa.FindAsync(id);
            if (ofertaMarketingowa != null)
            {
                ofertaMarketingowa.MarkAsDeleted();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfertaMarketingowaExists(int id)
        {
            return _context.OfertaMarketingowa.Any(e => e.IdOfertyMarketingowej == id);
        }
    }
}

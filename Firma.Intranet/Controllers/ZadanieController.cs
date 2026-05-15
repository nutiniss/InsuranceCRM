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
    public class ZadanieController : Controller
    {
        private readonly FirmaContext _context;

        public ZadanieController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Zadanie
        public async Task<IActionResult> Index()
        {
            var firmaContext = _context.Zadanie.Include(z => z.Klient).Include(z => z.Oferta).Include(z => z.Polisa).Include(z => z.Uzytkownik).Include(z => z.Zgloszenie);
            return View(await firmaContext.ToListAsync());
        }

        // GET: Zadanie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadanie = await _context.Zadanie
                .Include(z => z.Klient)
                .Include(z => z.Oferta)
                .Include(z => z.Polisa)
                .Include(z => z.Uzytkownik)
                .Include(z => z.Zgloszenie)
                .FirstOrDefaultAsync(m => m.IdZadania == id);
            if (zadanie == null)
            {
                return NotFound();
            }

            await this.LoadSlownikAsync(_context, "TypyZadania", TypSlownika.TypZadania, zadanie.Typ);
            await this.LoadSlownikAsync(_context, "StatusyZadania", TypSlownika.StatusZadania, zadanie.Status);
            return View(zadanie);
        }

        // GET: Zadanie/Create
        public async Task<IActionResult> Create()
        {

            await this.LoadSlownikAsync(_context, "TypyZadania", TypSlownika.TypZadania);
            await this.LoadSlownikAsync(_context, "StatusyZadania", TypSlownika.StatusZadania);
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email");
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty");
            ViewData["IdPolisy"] = new SelectList(_context.Set<Polisa>(), "IdPolisy", "NumerPolisy");
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email");
            ViewData["IdZgloszenia"] = new SelectList(_context.Set<Zgloszenie>(), "IdZgloszenia", "NumerZgloszenia");
            return View();
        }

        // POST: Zadanie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZadania,Nazwa,Opis,Typ,Status,DataUtworzenia,DataRealizacji,IdKlienta,IdUzytkownika,IdZgloszenia,IdOferty,IdPolisy")] Zadanie zadanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zadanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", zadanie.IdKlienta);
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty", zadanie.IdOferty);
            ViewData["IdPolisy"] = new SelectList(_context.Set<Polisa>(), "IdPolisy", "NumerPolisy", zadanie.IdPolisy);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", zadanie.IdUzytkownika);
            ViewData["IdZgloszenia"] = new SelectList(_context.Set<Zgloszenie>(), "IdZgloszenia", "NumerZgloszenia", zadanie.IdZgloszenia);
            await this.LoadSlownikAsync(_context, "TypyZadania", TypSlownika.TypZadania, zadanie.Typ);
            await this.LoadSlownikAsync(_context, "StatusyZadania", TypSlownika.StatusZadania, zadanie.Status);
            return View(zadanie);
        }

        // GET: Zadanie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadanie = await _context.Zadanie.FindAsync(id);
            if (zadanie == null)
            {
                return NotFound();
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", zadanie.IdKlienta);
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty", zadanie.IdOferty);
            ViewData["IdPolisy"] = new SelectList(_context.Set<Polisa>(), "IdPolisy", "NumerPolisy", zadanie.IdPolisy);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", zadanie.IdUzytkownika);
            ViewData["IdZgloszenia"] = new SelectList(_context.Set<Zgloszenie>(), "IdZgloszenia", "NumerZgloszenia", zadanie.IdZgloszenia);
            await this.LoadSlownikAsync(_context, "TypyZadania", TypSlownika.TypZadania, zadanie.Typ);
            await this.LoadSlownikAsync(_context, "StatusyZadania", TypSlownika.StatusZadania, zadanie.Status);
            return View(zadanie);
        }

        // POST: Zadanie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZadania,Nazwa,Opis,Typ,Status,DataUtworzenia,DataRealizacji,IdKlienta,IdUzytkownika,IdZgloszenia,IdOferty,IdPolisy")] Zadanie zadanie)
        {
            if (id != zadanie.IdZadania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zadanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZadanieExists(zadanie.IdZadania))
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
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", zadanie.IdKlienta);
            ViewData["IdOferty"] = new SelectList(_context.Oferta, "IdOferty", "NumerOferty", zadanie.IdOferty);
            ViewData["IdPolisy"] = new SelectList(_context.Set<Polisa>(), "IdPolisy", "NumerPolisy", zadanie.IdPolisy);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", zadanie.IdUzytkownika);
            ViewData["IdZgloszenia"] = new SelectList(_context.Set<Zgloszenie>(), "IdZgloszenia", "NumerZgloszenia", zadanie.IdZgloszenia);
            await this.LoadSlownikAsync(_context, "TypyZadania", TypSlownika.TypZadania, zadanie.Typ);
            await this.LoadSlownikAsync(_context, "StatusyZadania", TypSlownika.StatusZadania, zadanie.Status);
            return View(zadanie);
        }

        // GET: Zadanie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zadanie = await _context.Zadanie
                .Include(z => z.Klient)
                .Include(z => z.Oferta)
                .Include(z => z.Polisa)
                .Include(z => z.Uzytkownik)
                .Include(z => z.Zgloszenie)
                .FirstOrDefaultAsync(m => m.IdZadania == id);
            if (zadanie == null)
            {
                return NotFound();
            }

            await this.LoadSlownikAsync(_context, "TypyZadania", TypSlownika.TypZadania, zadanie.Typ);
            await this.LoadSlownikAsync(_context, "StatusyZadania", TypSlownika.StatusZadania, zadanie.Status);
            return View(zadanie);
        }

        // POST: Zadanie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zadanie = await _context.Zadanie.FindAsync(id);
            if (zadanie != null)
            {
                zadanie.MarkAsDeleted();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZadanieExists(int id)
        {
            return _context.Zadanie.Any(e => e.IdZadania == id);
        }
    }
}

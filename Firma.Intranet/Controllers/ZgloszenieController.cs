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
    public class ZgloszenieController : Controller
    {
        private readonly FirmaContext _context;

        public ZgloszenieController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Zgloszenie
        public async Task<IActionResult> Index()
        {
            var firmaContext = _context.Zgloszenie.Include(z => z.Klient).Include(z => z.Uzytkownik);
            return View(await firmaContext.ToListAsync());
        }

        // GET: Zgloszenie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zgloszenie = await _context.Zgloszenie
                .Include(z => z.Klient)
                .Include(z => z.Uzytkownik)
                .FirstOrDefaultAsync(m => m.IdZgloszenia == id);
            if (zgloszenie == null)
            {
                return NotFound();
            }

            return View(zgloszenie);
        }

        // GET: Zgloszenie/Create
        public IActionResult Create()
        {
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email");
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email");
            return View();
        }

        // POST: Zgloszenie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZgloszenia,NumerZgloszenia,Tytul,Opis,Typ,Status,DataUtworzenia,DataZamkniecia,IdKlienta,IdUzytkownika")] Zgloszenie zgloszenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zgloszenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", zgloszenie.IdKlienta);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", zgloszenie.IdUzytkownika);
            return View(zgloszenie);
        }

        // GET: Zgloszenie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zgloszenie = await _context.Zgloszenie.FindAsync(id);
            if (zgloszenie == null)
            {
                return NotFound();
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", zgloszenie.IdKlienta);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", zgloszenie.IdUzytkownika);
            return View(zgloszenie);
        }

        // POST: Zgloszenie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZgloszenia,NumerZgloszenia,Tytul,Opis,Typ,Status,DataUtworzenia,DataZamkniecia,IdKlienta,IdUzytkownika")] Zgloszenie zgloszenie)
        {
            if (id != zgloszenie.IdZgloszenia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zgloszenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZgloszenieExists(zgloszenie.IdZgloszenia))
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
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", zgloszenie.IdKlienta);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", zgloszenie.IdUzytkownika);
            return View(zgloszenie);
        }

        // GET: Zgloszenie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zgloszenie = await _context.Zgloszenie
                .Include(z => z.Klient)
                .Include(z => z.Uzytkownik)
                .FirstOrDefaultAsync(m => m.IdZgloszenia == id);
            if (zgloszenie == null)
            {
                return NotFound();
            }

            return View(zgloszenie);
        }

        // POST: Zgloszenie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zgloszenie = await _context.Zgloszenie.FindAsync(id);
            if (zgloszenie != null)
            {
                _context.Zgloszenie.Remove(zgloszenie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZgloszenieExists(int id)
        {
            return _context.Zgloszenie.Any(e => e.IdZgloszenia == id);
        }
    }
}

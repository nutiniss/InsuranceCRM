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
    public class WiadomoscController : Controller
    {
        private readonly FirmaContext _context;

        public WiadomoscController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Wiadomosc
        public async Task<IActionResult> Index()
        {
            var firmaContext = _context.Wiadomosc.Include(w => w.Klient).Include(w => w.Uzytkownik);
            return View(await firmaContext.ToListAsync());
        }

        // GET: Wiadomosc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomosc = await _context.Wiadomosc
                .Include(w => w.Klient)
                .Include(w => w.Uzytkownik)
                .FirstOrDefaultAsync(m => m.IdWiadomosci == id);
            if (wiadomosc == null)
            {
                return NotFound();
            }

            return View(wiadomosc);
        }

        // GET: Wiadomosc/Create
        public IActionResult Create()
        {
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email");
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email");
            return View();
        }

        // POST: Wiadomosc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWiadomosci,Temat,Tresc,Typ,DataUtworzenia,DataWyslania,CzyPrzeczytana,IdKlienta,IdUzytkownika")] Wiadomosc wiadomosc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wiadomosc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", wiadomosc.IdKlienta);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", wiadomosc.IdUzytkownika);
            return View(wiadomosc);
        }

        // GET: Wiadomosc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomosc = await _context.Wiadomosc.FindAsync(id);
            if (wiadomosc == null)
            {
                return NotFound();
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", wiadomosc.IdKlienta);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", wiadomosc.IdUzytkownika);
            return View(wiadomosc);
        }

        // POST: Wiadomosc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWiadomosci,Temat,Tresc,Typ,DataUtworzenia,DataWyslania,CzyPrzeczytana,IdKlienta,IdUzytkownika")] Wiadomosc wiadomosc)
        {
            if (id != wiadomosc.IdWiadomosci)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wiadomosc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WiadomoscExists(wiadomosc.IdWiadomosci))
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
            ViewData["IdKlienta"] = new SelectList(_context.Klient, "IdKlienta", "Email", wiadomosc.IdKlienta);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "Email", wiadomosc.IdUzytkownika);
            return View(wiadomosc);
        }

        // GET: Wiadomosc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wiadomosc = await _context.Wiadomosc
                .Include(w => w.Klient)
                .Include(w => w.Uzytkownik)
                .FirstOrDefaultAsync(m => m.IdWiadomosci == id);
            if (wiadomosc == null)
            {
                return NotFound();
            }

            return View(wiadomosc);
        }

        // POST: Wiadomosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wiadomosc = await _context.Wiadomosc.FindAsync(id);
            if (wiadomosc != null)
            {
                _context.Wiadomosc.Remove(wiadomosc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WiadomoscExists(int id)
        {
            return _context.Wiadomosc.Any(e => e.IdWiadomosci == id);
        }
    }
}

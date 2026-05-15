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
    public class ProduktUbezpieczeniowyController : Controller
    {
        private readonly FirmaContext _context;

        public ProduktUbezpieczeniowyController(FirmaContext context)
        {
            _context = context;
        }

        // GET: ProduktUbezpieczeniowy
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProduktUbezpieczeniowy.ToListAsync());
        }

        // GET: ProduktUbezpieczeniowy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produktUbezpieczeniowy = await _context.ProduktUbezpieczeniowy
                .FirstOrDefaultAsync(m => m.IdProduktuUbezpieczeniowego == id);
            if (produktUbezpieczeniowy == null)
            {
                return NotFound();
            }

            return View(produktUbezpieczeniowy);
        }

        // GET: ProduktUbezpieczeniowy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProduktUbezpieczeniowy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduktuUbezpieczeniowego,Kod,Nazwa,Kategoria,Opis,CzyAktywny")] ProduktUbezpieczeniowy produktUbezpieczeniowy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produktUbezpieczeniowy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produktUbezpieczeniowy);
        }

        // GET: ProduktUbezpieczeniowy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produktUbezpieczeniowy = await _context.ProduktUbezpieczeniowy.FindAsync(id);
            if (produktUbezpieczeniowy == null)
            {
                return NotFound();
            }
            return View(produktUbezpieczeniowy);
        }

        // POST: ProduktUbezpieczeniowy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduktuUbezpieczeniowego,Kod,Nazwa,Kategoria,Opis,CzyAktywny")] ProduktUbezpieczeniowy produktUbezpieczeniowy)
        {
            if (id != produktUbezpieczeniowy.IdProduktuUbezpieczeniowego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produktUbezpieczeniowy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktUbezpieczeniowyExists(produktUbezpieczeniowy.IdProduktuUbezpieczeniowego))
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
            return View(produktUbezpieczeniowy);
        }

        // GET: ProduktUbezpieczeniowy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produktUbezpieczeniowy = await _context.ProduktUbezpieczeniowy
                .FirstOrDefaultAsync(m => m.IdProduktuUbezpieczeniowego == id);
            if (produktUbezpieczeniowy == null)
            {
                return NotFound();
            }

            return View(produktUbezpieczeniowy);
        }

        // POST: ProduktUbezpieczeniowy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produktUbezpieczeniowy = await _context.ProduktUbezpieczeniowy.FindAsync(id);
            if (produktUbezpieczeniowy != null)
            {
                _context.ProduktUbezpieczeniowy.Remove(produktUbezpieczeniowy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktUbezpieczeniowyExists(int id)
        {
            return _context.ProduktUbezpieczeniowy.Any(e => e.IdProduktuUbezpieczeniowego == id);
        }
    }
}

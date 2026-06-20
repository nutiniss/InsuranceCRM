using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Firma.Data.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers;

public class TekstPortaluController : Controller
{
    private readonly FirmaContext _context;

    public TekstPortaluController(FirmaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var teksty = await _context.TekstPortalu
            .OrderBy(tekst => tekst.Kolejnosc)
            .ThenBy(tekst => tekst.Klucz)
            .ToListAsync();

        return View(teksty);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tekst = await _context.TekstPortalu.FirstOrDefaultAsync(m => m.IdTekstuPortalu == id);
        return tekst == null ? NotFound() : View(tekst);
    }

    public IActionResult Create()
    {
        return View(new TekstPortalu
        {
            Klucz = string.Empty,
            Tytul = string.Empty,
            Tresc = string.Empty,
            CzyAktywny = true,
            DataUtworzenia = DateTime.Now
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdTekstuPortalu,Klucz,Tytul,Tresc,Kolejnosc,CzyAktywny,DataUtworzenia,DataModyfikacji,StatusRekordu")] TekstPortalu tekstPortalu)
    {
        if (ModelState.IsValid)
        {
            tekstPortalu.DataUtworzenia = DateTime.Now;
            _context.Add(tekstPortalu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(tekstPortalu);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tekstPortalu = await _context.TekstPortalu.FindAsync(id);
        return tekstPortalu == null ? NotFound() : View(tekstPortalu);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdTekstuPortalu,Klucz,Tytul,Tresc,Kolejnosc,CzyAktywny,DataUtworzenia,DataModyfikacji,StatusRekordu")] TekstPortalu tekstPortalu)
    {
        if (id != tekstPortalu.IdTekstuPortalu)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                tekstPortalu.DataModyfikacji = DateTime.Now;
                _context.Update(tekstPortalu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TekstPortaluExists(tekstPortalu.IdTekstuPortalu))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(tekstPortalu);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tekst = await _context.TekstPortalu.FirstOrDefaultAsync(m => m.IdTekstuPortalu == id);
        return tekst == null ? NotFound() : View(tekst);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var tekst = await _context.TekstPortalu.FindAsync(id);
        if (tekst != null)
        {
            tekst.StatusRekordu = RecordStatus.Deleted;
            tekst.CzyAktywny = false;
            tekst.DataModyfikacji = DateTime.Now;
            _context.Update(tekst);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> TekstPortaluExists(int id)
    {
        return await _context.TekstPortalu.AnyAsync(e => e.IdTekstuPortalu == id);
    }
}

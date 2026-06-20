using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers;

public class StronaPortaluController : Controller
{
    private readonly FirmaContext _context;

    public StronaPortaluController(FirmaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var strony = await _context.StronaPortalu
            .OrderBy(strona => strona.Kolejnosc)
            .ThenBy(strona => strona.TytulMenu)
            .ToListAsync();

        return View(strony);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var strona = await _context.StronaPortalu.FirstOrDefaultAsync(m => m.IdStronyPortalu == id);
        return strona == null ? NotFound() : View(strona);
    }

    public IActionResult Create()
    {
        return View(new StronaPortalu
        {
            Slug = string.Empty,
            TytulMenu = string.Empty,
            Tytul = string.Empty,
            Tresc = string.Empty,
            Kolejnosc = 1,
            CzyAktywna = true,
            CzyWidocznaWMenu = true,
            DataUtworzenia = DateTime.Now
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdStronyPortalu,Slug,TytulMenu,Tytul,NaglowekPomocniczy,Tresc,Kolejnosc,CzyWidocznaWMenu,CzyAktywna,DataUtworzenia,DataModyfikacji,StatusRekordu")] StronaPortalu stronaPortalu)
    {
        if (ModelState.IsValid)
        {
            stronaPortalu.DataUtworzenia = DateTime.Now;
            _context.Add(stronaPortalu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(stronaPortalu);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stronaPortalu = await _context.StronaPortalu.FindAsync(id);
        return stronaPortalu == null ? NotFound() : View(stronaPortalu);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdStronyPortalu,Slug,TytulMenu,Tytul,NaglowekPomocniczy,Tresc,Kolejnosc,CzyWidocznaWMenu,CzyAktywna,DataUtworzenia,DataModyfikacji,StatusRekordu")] StronaPortalu stronaPortalu)
    {
        if (id != stronaPortalu.IdStronyPortalu)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                stronaPortalu.DataModyfikacji = DateTime.Now;
                _context.Update(stronaPortalu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StronaPortaluExists(stronaPortalu.IdStronyPortalu))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(stronaPortalu);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var strona = await _context.StronaPortalu.FirstOrDefaultAsync(m => m.IdStronyPortalu == id);
        return strona == null ? NotFound() : View(strona);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var strona = await _context.StronaPortalu.FindAsync(id);
        if (strona != null)
        {
            strona.StatusRekordu = Firma.Data.Data.Common.RecordStatus.Deleted;
            strona.CzyAktywna = false;
            strona.DataModyfikacji = DateTime.Now;
            _context.Update(strona);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> StronaPortaluExists(int id)
    {
        return await _context.StronaPortalu.AnyAsync(e => e.IdStronyPortalu == id);
    }
}

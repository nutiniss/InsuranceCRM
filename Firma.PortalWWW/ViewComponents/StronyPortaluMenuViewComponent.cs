using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.ViewComponents;

public class StronyPortaluMenuViewComponent : ViewComponent
{
    private readonly FirmaContext _context;

    public StronyPortaluMenuViewComponent(FirmaContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(string? aktywnySlug = null)
    {
        ViewBag.AktywnySlug = aktywnySlug;
        var strony = await _context.StronaPortalu
            .AsNoTracking()
            .Where(strona => strona.CzyAktywna && strona.CzyWidocznaWMenu)
            .OrderBy(strona => strona.Kolejnosc)
            .ThenBy(strona => strona.TytulMenu)
            .ToListAsync();

        return View(strony);
    }
}

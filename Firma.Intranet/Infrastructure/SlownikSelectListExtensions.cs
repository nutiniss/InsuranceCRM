using Firma.Data.Data;
using Firma.Data.Data.Ubezpieczenia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Infrastructure;

public static class SlownikSelectListExtensions
{
    public static async Task LoadSlownikAsync(
        this Controller controller,
        FirmaContext context,
        string viewDataKey,
        string typSlownika,
        string? selectedValue = null)
    {
        var pozycje = await context.PozycjaSlownika
            .AsNoTracking()
            .Where(p => p.Typ == typSlownika && p.CzyAktywna)
            .OrderBy(p => p.Kolejnosc)
            .ThenBy(p => p.Wartosc)
            .ToListAsync();

        controller.ViewData[viewDataKey] = new SelectList(
            pozycje,
            nameof(PozycjaSlownika.Wartosc),
            nameof(PozycjaSlownika.Wartosc),
            selectedValue);
    }
}

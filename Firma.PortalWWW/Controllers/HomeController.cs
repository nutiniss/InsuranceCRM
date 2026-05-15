using Firma.Data.Data;
using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly FirmaContext _context;

        public HomeController(FirmaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Start));
        }

        public async Task<IActionResult> Start()
        {
            var teraz = DateTime.Now;
            var ofertyMarketingowe = await _context.OfertaMarketingowa
                .AsNoTracking()
                .Where(oferta => oferta.CzyAktywna
                    && (!oferta.DataPublikacji.HasValue || oferta.DataPublikacji <= teraz)
                    && (!oferta.DataWaznosci.HasValue || oferta.DataWaznosci >= teraz))
                .OrderByDescending(oferta => oferta.DataPublikacji ?? oferta.DataUtworzenia)
                .Take(6)
                .ToListAsync();

            return View(ofertyMarketingowe);
        }

        public async Task<IActionResult> Zgloszenia()
        {
            var zgloszenia = await _context.Zgloszenie
                .AsNoTracking()
                .Include(zgloszenie => zgloszenie.Uzytkownik)
                .OrderByDescending(zgloszenie => zgloszenie.DataUtworzenia)
                .Take(12)
                .ToListAsync();

            return View(new ClientPortalListViewModel<Firma.Data.Data.Ubezpieczenia.Zgloszenie>
            {
                Title = "Zgłoszenia",
                Eyebrow = "Obsługa klienta",
                Description = "Monitoruj zgłoszenia, statusy spraw oraz kontakt z opiekunem ubezpieczeniowym.",
                SummaryLabel = "Otwarte sprawy",
                SummaryCaption = "zgłoszeń widocznych w portalu",
                Items = zgloszenia
            });
        }

        public async Task<IActionResult> Wiadomosci()
        {
            var wiadomosci = await _context.Wiadomosc
                .AsNoTracking()
                .Include(wiadomosc => wiadomosc.Uzytkownik)
                .OrderByDescending(wiadomosc => wiadomosc.DataWyslania ?? wiadomosc.DataUtworzenia)
                .Take(12)
                .ToListAsync();

            return View(new ClientPortalListViewModel<Firma.Data.Data.Ubezpieczenia.Wiadomosc>
            {
                Title = "Wiadomości",
                Eyebrow = "Centrum komunikacji",
                Description = "Przeglądaj wiadomości od opiekuna, powiadomienia systemowe i ważne informacje dotyczące polis.",
                SummaryLabel = "Nieprzeczytane",
                SummaryCaption = "wiadomości wymagających uwagi",
                Items = wiadomosci
            });
        }

        public async Task<IActionResult> MojePolisy()
        {
            var polisy = await _context.Polisa
                .AsNoTracking()
                .Include(polisa => polisa.ProduktUbezpieczeniowy)
                .Include(polisa => polisa.Uzytkownik)
                .OrderBy(polisa => polisa.KoniecOchrony)
                .Take(12)
                .ToListAsync();

            return View(new ClientPortalListViewModel<Firma.Data.Data.Ubezpieczenia.Polisa>
            {
                Title = "Moje polisy",
                Eyebrow = "Portfel ubezpieczeń",
                Description = "Sprawdzaj aktywne polisy, terminy ochrony, składki oraz produkty przypisane do Twojego konta.",
                SummaryLabel = "Aktywne polisy",
                SummaryCaption = "polis w portfelu",
                Items = polisy
            });
        }

        public async Task<IActionResult> MojeOferty()
        {
            var teraz = DateTime.Now;
            var oferty = await _context.Oferta
                .AsNoTracking()
                .Include(oferta => oferta.ProduktUbezpieczeniowy)
                .Include(oferta => oferta.Uzytkownik)
                .OrderByDescending(oferta => oferta.DataUtworzenia)
                .Take(12)
                .ToListAsync();

            var ofertyMarketingowe = await _context.OfertaMarketingowa
                .AsNoTracking()
                .Where(oferta => oferta.CzyAktywna
                    && (!oferta.DataPublikacji.HasValue || oferta.DataPublikacji <= teraz)
                    && (!oferta.DataWaznosci.HasValue || oferta.DataWaznosci >= teraz))
                .OrderByDescending(oferta => oferta.DataPublikacji ?? oferta.DataUtworzenia)
                .Take(6)
                .ToListAsync();

            return View(new ClientPortalOffersViewModel
            {
                PersonalOffers = oferty,
                MarketingOffers = ofertyMarketingowe
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

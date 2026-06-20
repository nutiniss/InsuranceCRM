using Firma.Data.Data;
using Firma.Data.Data.CMS;
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

            ViewBag.HeroTekst = await PobierzTekstPortaluAsync(
                "portal.start.hero",
                "Witaj w swoim centrum ubezpieczeń",
                "Sprawdzaj polisy, dodawaj zgłoszenia i korzystaj z aktualnych propozycji przygotowanych przez agentów.");

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

            var tekstNaglowka = await PobierzTekstPortaluAsync(
                "portal.zgloszenia.hero",
                "Zgłoszenia",
                "Monitoruj zgłoszenia, statusy spraw oraz kontakt z opiekunem ubezpieczeniowym.");

            return View(new ClientPortalListViewModel<Firma.Data.Data.Ubezpieczenia.Zgloszenie>
            {
                Title = tekstNaglowka.Tytul,
                Eyebrow = "Obsługa klienta",
                Description = tekstNaglowka.Tresc,
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

            var tekstNaglowka = await PobierzTekstPortaluAsync(
                "portal.wiadomosci.hero",
                "Wiadomości",
                "Przeglądaj wiadomości od opiekuna, powiadomienia systemowe i ważne informacje dotyczące polis.");

            return View(new ClientPortalListViewModel<Firma.Data.Data.Ubezpieczenia.Wiadomosc>
            {
                Title = tekstNaglowka.Tytul,
                Eyebrow = "Centrum komunikacji",
                Description = tekstNaglowka.Tresc,
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

            var tekstNaglowka = await PobierzTekstPortaluAsync(
                "portal.polisy.hero",
                "Moje polisy",
                "Sprawdzaj aktywne polisy, terminy ochrony, składki oraz produkty przypisane do Twojego konta.");

            return View(new ClientPortalListViewModel<Firma.Data.Data.Ubezpieczenia.Polisa>
            {
                Title = tekstNaglowka.Tytul,
                Eyebrow = "Portfel ubezpieczeń",
                Description = tekstNaglowka.Tresc,
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

            ViewBag.HeroTekst = await PobierzTekstPortaluAsync(
                "portal.oferty.hero",
                "Moje oferty",
                "Porównaj przygotowane propozycje ubezpieczeniowe oraz aktualne komunikaty marketingowe dostępne w portalu klienta.");

            return View(new ClientPortalOffersViewModel
            {
                PersonalOffers = oferty,
                MarketingOffers = ofertyMarketingowe
            });
        }

        public async Task<IActionResult> Agenci()
        {
            var agenci = await _context.Uzytkownik
                .AsNoTracking()
                .Where(uzytkownik => uzytkownik.CzyAktywny
                    && uzytkownik.Rola == "Agent")
                .OrderBy(uzytkownik => uzytkownik.Nazwisko)
                .ThenBy(uzytkownik => uzytkownik.Imie)
                .ToListAsync();

            var tekstNaglowka = await PobierzTekstPortaluAsync(
                "portal.agenci.hero",
                "Agenci",
                "Wybierz agenta, z którym chcesz porozmawiać o swojej polisie, zgłoszeniu lub nowej ofercie.");

            return View(new ClientPortalListViewModel<Firma.Data.Data.Ubezpieczenia.Uzytkownik>
            {
                Title = tekstNaglowka.Tytul,
                Eyebrow = "Kontakt z opiekunem",
                Description = tekstNaglowka.Tresc,
                SummaryLabel = "Dostępni agenci",
                SummaryCaption = "aktywnych opiekunów klienta",
                Items = agenci
            });
        }

        private async Task<TekstPortalu> PobierzTekstPortaluAsync(string klucz, string domyslnyTytul, string domyslnaTresc)
        {
            var tekst = await _context.TekstPortalu
                .AsNoTracking()
                .FirstOrDefaultAsync(tekst => tekst.Klucz == klucz && tekst.CzyAktywny);

            return tekst ?? new TekstPortalu
            {
                Klucz = klucz,
                Tytul = domyslnyTytul,
                Tresc = domyslnaTresc
            };
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

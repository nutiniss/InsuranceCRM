using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Firma.PortalWWW.Models;
using Firma.Data.Data.Ubezpieczenia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private const int DefaultPortalClientId = 1;
        private readonly FirmaContext _context;
        private readonly IConfiguration _configuration;

        public HomeController(FirmaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Start));
        }

        public async Task<IActionResult> Start()
        {
            await PrzygotujPowiadomieniaAsync();
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
            await PrzygotujPowiadomieniaAsync();
            var idKlienta = await PobierzIdKlientaPortaluAsync();
            var zgloszenia = await _context.Zgloszenie
                .AsNoTracking()
                .Include(zgloszenie => zgloszenie.Uzytkownik)
                .Where(zgloszenie => zgloszenie.IdKlienta == idKlienta)
                .OrderByDescending(zgloszenie => zgloszenie.DataUtworzenia)
                .Take(12)
                .ToListAsync();

            var tekstNaglowka = await PobierzTekstPortaluAsync(
                "portal.zgloszenia.hero",
                "Zgłoszenia",
                "Monitoruj zgłoszenia, statusy spraw oraz kontakt z opiekunem ubezpieczeniowym.");

            return View(new ClientPortalClaimsViewModel
            {
                NewClaim = new PortalClaimFormViewModel(),
                Agents = await PobierzAgentowAsync(),
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
            await PrzygotujPowiadomieniaAsync();
            var idKlienta = await PobierzIdKlientaPortaluAsync();
            var wiadomosci = await _context.Wiadomosc
                .AsNoTracking()
                .Include(wiadomosc => wiadomosc.Uzytkownik)
                .Where(wiadomosc => wiadomosc.IdKlienta == idKlienta)
                .OrderByDescending(wiadomosc => wiadomosc.DataWyslania ?? wiadomosc.DataUtworzenia)
                .Take(12)
                .ToListAsync();

            var tekstNaglowka = await PobierzTekstPortaluAsync(
                "portal.wiadomosci.hero",
                "Wiadomości",
                "Przeglądaj wiadomości od opiekuna, powiadomienia systemowe i ważne informacje dotyczące polis.");

            return View(new ClientPortalMessagesViewModel
            {
                NewMessage = new PortalMessageFormViewModel { IdUzytkownika = await PobierzDomyslnegoAgentaIdAsync() },
                Agents = await PobierzAgentowAsync(),
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
            await PrzygotujPowiadomieniaAsync();
            var idKlienta = await PobierzIdKlientaPortaluAsync();
            var polisy = await _context.Polisa
                .AsNoTracking()
                .Include(polisa => polisa.ProduktUbezpieczeniowy)
                .Include(polisa => polisa.Uzytkownik)
                .Where(polisa => polisa.IdKlienta == idKlienta)
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
            await PrzygotujPowiadomieniaAsync();
            var idKlienta = await PobierzIdKlientaPortaluAsync();
            var teraz = DateTime.Now;
            var oferty = await _context.Oferta
                .AsNoTracking()
                .Include(oferta => oferta.ProduktUbezpieczeniowy)
                .Include(oferta => oferta.Uzytkownik)
                .Where(oferta => oferta.IdKlienta == idKlienta)
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
                "Porównaj przygotowane propozycje ubezpieczeniowe oraz aktualne oferty promocyjne dostępne w portalu klienta.");

            return View(new ClientPortalOffersViewModel
            {
                PersonalOffers = oferty,
                MarketingOffers = ofertyMarketingowe
            });
        }

        public async Task<IActionResult> Agenci()
        {
            await PrzygotujPowiadomieniaAsync();
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WyslijWiadomosc(PortalMessageFormViewModel form)
        {
            if (!ModelState.IsValid)
            {
                TempData["PortalError"] = "Uzupełnij poprawnie formularz wiadomości.";
                return RedirectToAction(nameof(Wiadomosci));
            }

            var agentExists = await _context.Uzytkownik.AnyAsync(uzytkownik => uzytkownik.IdUzytkownika == form.IdUzytkownika && uzytkownik.CzyAktywny);
            if (!agentExists)
            {
                TempData["PortalError"] = "Wybrany agent nie jest dostępny.";
                return RedirectToAction(nameof(Wiadomosci));
            }

            _context.Wiadomosc.Add(new Wiadomosc
            {
                Temat = form.Temat,
                Tresc = form.Tresc,
                Typ = "Wiadomość klienta",
                DataUtworzenia = DateTime.Now,
                DataWyslania = DateTime.Now,
                CzyPrzeczytana = false,
                IdKlienta = await PobierzIdKlientaPortaluAsync(),
                IdUzytkownika = form.IdUzytkownika
            });
            await _context.SaveChangesAsync();
            TempData["PortalSuccess"] = "Wiadomość została wysłana do agenta.";
            return RedirectToAction(nameof(Wiadomosci));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UtworzZgloszenie(PortalClaimFormViewModel form)
        {
            if (!ModelState.IsValid)
            {
                TempData["PortalError"] = "Uzupełnij poprawnie formularz zgłoszenia.";
                return RedirectToAction(nameof(Zgloszenia));
            }

            var agentId = await PobierzDomyslnegoAgentaIdAsync();
            _context.Zgloszenie.Add(new Zgloszenie
            {
                NumerZgloszenia = $"ZG-{DateTime.Now:yyyyMMddHHmmss}",
                Tytul = form.Tytul,
                Opis = form.Opis,
                Typ = form.Typ,
                Status = "Nowe",
                DataUtworzenia = DateTime.Now,
                IdKlienta = await PobierzIdKlientaPortaluAsync(),
                IdUzytkownika = agentId == 0 ? null : agentId
            });
            await _context.SaveChangesAsync();
            TempData["PortalSuccess"] = "Zgłoszenie zostało utworzone.";
            return RedirectToAction(nameof(Zgloszenia));
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OznaczWiadomoscJakoPrzeczytana(int id)
        {
            var idKlienta = await PobierzIdKlientaPortaluAsync();
            var wiadomosc = await _context.Wiadomosc
                .FirstOrDefaultAsync(wiadomosc => wiadomosc.IdWiadomosci == id && wiadomosc.IdKlienta == idKlienta);

            if (wiadomosc == null)
            {
                TempData["PortalError"] = "Nie znaleziono wiadomości do oznaczenia.";
                return RedirectToAction(nameof(Wiadomosci));
            }

            if (!CzyWiadomoscWymagaOdczytaniaPrzezKlienta(wiadomosc))
            {
                TempData["PortalSuccess"] = "Wiadomość jest już oznaczona jako przeczytana.";
                return RedirectToAction(nameof(Wiadomosci));
            }

            wiadomosc.CzyPrzeczytana = true;
            await _context.SaveChangesAsync();
            TempData["PortalSuccess"] = "Wiadomość została oznaczona jako przeczytana.";
            return RedirectToAction(nameof(Wiadomosci));
        }


        public async Task<IActionResult> Powiadomienia()
        {
            var idKlienta = await PobierzIdKlientaPortaluAsync();
            var nieprzeczytane = await _context.Wiadomosc
                .Where(wiadomosc => wiadomosc.IdKlienta == idKlienta
                    && !wiadomosc.CzyPrzeczytana
                    && wiadomosc.Typ != "Wiadomość klienta")
                .ToListAsync();

            if (nieprzeczytane.Count > 0)
            {
                foreach (var wiadomosc in nieprzeczytane)
                {
                    wiadomosc.CzyPrzeczytana = true;
                }

                await _context.SaveChangesAsync();
                TempData["PortalSuccess"] = "Powiadomienia zostały oznaczone jako przeczytane.";
            }

            return RedirectToAction(nameof(Wiadomosci));
        }


        private static bool CzyWiadomoscWymagaOdczytaniaPrzezKlienta(Wiadomosc wiadomosc)
        {
            return !wiadomosc.CzyPrzeczytana && wiadomosc.Typ != "Wiadomość klienta";
        }

        private async Task PrzygotujPowiadomieniaAsync()
        {
            var idKlienta = await PobierzIdKlientaPortaluAsync();
            var klient = await _context.Klient
                .AsNoTracking()
                .Where(klient => klient.IdKlienta == idKlienta)
                .Select(klient => new { klient.Imie, klient.Nazwisko })
                .FirstOrDefaultAsync();

            ViewBag.PortalClientName = klient is null ? "Klient" : $"{klient.Imie} {klient.Nazwisko}";
            ViewBag.UnreadMessages = await _context.Wiadomosc.CountAsync(wiadomosc => wiadomosc.IdKlienta == idKlienta
                && !wiadomosc.CzyPrzeczytana
                && wiadomosc.Typ != "Wiadomość klienta");
        }

        private async Task<int> PobierzIdKlientaPortaluAsync()
        {
            var claimValue = User.FindFirstValue("IdKlienta") ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(claimValue, out var claimClientId) && await CzyKlientIstniejeAsync(claimClientId))
            {
                return claimClientId;
            }

            var configuredClientId = _configuration.GetValue<int?>("ClientPortal:ClientId") ?? DefaultPortalClientId;
            return await CzyKlientIstniejeAsync(configuredClientId)
                ? configuredClientId
                : await _context.Klient.AsNoTracking().OrderBy(klient => klient.IdKlienta).Select(klient => klient.IdKlienta).FirstAsync();
        }

        private async Task<bool> CzyKlientIstniejeAsync(int idKlienta)
        {
            return await _context.Klient.AsNoTracking().AnyAsync(klient => klient.IdKlienta == idKlienta);
        }

        private async Task<List<Uzytkownik>> PobierzAgentowAsync()
        {
            return await _context.Uzytkownik
                .AsNoTracking()
                .Where(uzytkownik => uzytkownik.CzyAktywny && (uzytkownik.Rola == "Agent" || uzytkownik.Rola == "Opiekun klienta"))
                .OrderBy(uzytkownik => uzytkownik.Nazwisko)
                .ThenBy(uzytkownik => uzytkownik.Imie)
                .ToListAsync();
        }

        private async Task<int> PobierzDomyslnegoAgentaIdAsync()
        {
            return await _context.Uzytkownik
                .Where(uzytkownik => uzytkownik.CzyAktywny && (uzytkownik.Rola == "Agent" || uzytkownik.Rola == "Opiekun klienta"))
                .OrderBy(uzytkownik => uzytkownik.Nazwisko)
                .Select(uzytkownik => uzytkownik.IdUzytkownika)
                .FirstOrDefaultAsync();
        }

        public async Task<IActionResult> Privacy()
        {
            await PrzygotujPowiadomieniaAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

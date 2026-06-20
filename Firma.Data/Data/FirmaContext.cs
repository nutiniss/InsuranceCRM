using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data.CMS;
using Firma.Data.Data.Common;
using Firma.Data.Data.Ubezpieczenia;

namespace Firma.Data.Data;

public class FirmaContext : DbContext
{
    public FirmaContext(DbContextOptions<FirmaContext> options)
        : base(options)
    {
    }

    public DbSet<Oferta> Oferta { get; set; } = default!;

    public DbSet<Klient> Klient { get; set; } = default!;

    public DbSet<OfertaMarketingowa> OfertaMarketingowa { get; set; } = default!;

    public DbSet<ProduktUbezpieczeniowy> ProduktUbezpieczeniowy { get; set; } = default!;

    public DbSet<Uzytkownik> Uzytkownik { get; set; } = default!;

    public DbSet<Wiadomosc> Wiadomosc { get; set; } = default!;

    public DbSet<Wycena> Wycena { get; set; } = default!;

    public DbSet<Zadanie> Zadanie { get; set; } = default!;

    public DbSet<Zgloszenie> Zgloszenie { get; set; } = default!;

    public DbSet<Polisa> Polisa { get; set; } = default!;

    public DbSet<PozycjaSlownika> PozycjaSlownika { get; set; } = default!;

    public DbSet<StronaPortalu> StronaPortalu { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Klient>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<Oferta>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<OfertaMarketingowa>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<Polisa>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<ProduktUbezpieczeniowy>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<Uzytkownik>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<Wiadomosc>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<Wycena>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<Zadanie>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<Zgloszenie>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<PozycjaSlownika>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);
        modelBuilder.Entity<StronaPortalu>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);

        modelBuilder.Entity<PozycjaSlownika>()
            .HasIndex(e => new { e.Typ, e.Wartosc })
            .IsUnique();

        modelBuilder.Entity<StronaPortalu>()
            .HasIndex(e => e.Slug)
            .IsUnique();

        modelBuilder.Entity<PozycjaSlownika>().HasData(PozycjeSlownikow());
        modelBuilder.Entity<StronaPortalu>().HasData(StronyPortalu());
    }

    private static StronaPortalu[] StronyPortalu()
    {
        return
        [
            new StronaPortalu
            {
                IdStronyPortalu = 1,
                Slug = "jak-zglosic-szkode",
                TytulMenu = "Zgłoszenie szkody",
                Tytul = "Jak zgłosić szkodę?",
                NaglowekPomocniczy = "Instrukcje dla klientów",
                Tresc = "Opisz zdarzenie, dołącz dokumenty i śledź status sprawy w zakładce Zgłoszenia. Po przyjęciu zgłoszenia opiekun skontaktuje się z Tobą z kolejnymi krokami.",
                Kolejnosc = 1,
                CzyWidocznaWMenu = true,
                CzyAktywna = true,
                DataUtworzenia = new DateTime(2026, 6, 20),
                StatusRekordu = RecordStatus.Active
            },
            new StronaPortalu
            {
                IdStronyPortalu = 2,
                Slug = "kontakt-z-agentem",
                TytulMenu = "Kontakt",
                Tytul = "Kontakt z agentem",
                NaglowekPomocniczy = "Wsparcie w portalu klienta",
                Tresc = "Wybierz opiekuna w zakładce Agenci albo wyślij wiadomość z portalu. Agent pomoże w sprawach polis, ofert, zgłoszeń oraz odnowień.",
                Kolejnosc = 2,
                CzyWidocznaWMenu = true,
                CzyAktywna = true,
                DataUtworzenia = new DateTime(2026, 6, 20),
                StatusRekordu = RecordStatus.Active
            }
        ];
    }

    private static PozycjaSlownika[] PozycjeSlownikow()
    {
        var id = 1;
        var pozycje = new List<PozycjaSlownika>();

        Add(TypSlownika.KategoriaProduktu, "Komunikacyjne", "Majątkowe", "Życiowe", "Zdrowotne", "Turystyczne", "Firmowe");
        Add(TypSlownika.StatusOferty, "Nowa", "W przygotowaniu", "Wysłana do klienta", "Zaakceptowana", "Odrzucona", "Wygasła");
        Add(TypSlownika.StatusPolisy, "Aktywna", "Oczekuje na start", "Wznowienie", "Zakończona", "Wypowiedziana", "Anulowana");
        Add(TypSlownika.TypZadania, "Kontakt z klientem", "Przygotowanie oferty", "Weryfikacja dokumentów", "Obsługa zgłoszenia", "Odnowienie polisy", "Czynność administracyjna");
        Add(TypSlownika.StatusZadania, "Nowe", "W toku", "Oczekuje na klienta", "Oczekuje na dokumenty", "Zrealizowane", "Anulowane");
        Add(TypSlownika.TypZgloszenia, "Szkoda", "Zmiana danych", "Pytanie o polisę", "Reklamacja", "Prośba o kontakt", "Inne");
        Add(TypSlownika.StatusZgloszenia, "Nowe", "Przyjęte", "W analizie", "Oczekuje na klienta", "Zamknięte", "Odrzucone");
        Add(TypSlownika.TypWiadomosci, "E-mail", "SMS", "Telefon", "Notatka", "Powiadomienie systemowe");
        Add(TypSlownika.RolaUzytkownika, "Agent", "Opiekun klienta", "Likwidator szkód", "Menedżer", "Administrator");
        Add(TypSlownika.MetodaWyceny, "Taryfa standardowa", "Indywidualna kalkulacja", "Wycena ekspercka", "Kalkulator online", "Odnowienie na podstawie historii");
        Add(TypSlownika.GrupaDocelowa, "Wszyscy klienci", "Nowi klienci", "Klienci indywidualni", "Klienci firmowi", "Klienci z aktywną polisą", "Klienci do odnowienia");

        return pozycje.ToArray();

        void Add(string typ, params string[] wartosci)
        {
            for (var kolejnosc = 0; kolejnosc < wartosci.Length; kolejnosc++)
            {
                pozycje.Add(new PozycjaSlownika
                {
                    IdPozycjiSlownika = id++,
                    Typ = typ,
                    Wartosc = wartosci[kolejnosc],
                    Kolejnosc = kolejnosc + 1,
                    CzyAktywna = true,
                    StatusRekordu = RecordStatus.Active
                });
            }
        }
    }
}

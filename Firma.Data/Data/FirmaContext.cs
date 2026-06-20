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

    public DbSet<TekstPortalu> TekstPortalu { get; set; } = default!;

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
        modelBuilder.Entity<TekstPortalu>().HasQueryFilter(e => e.StatusRekordu != RecordStatus.Deleted);

        modelBuilder.Entity<PozycjaSlownika>()
            .HasIndex(e => new { e.Typ, e.Wartosc })
            .IsUnique();

        modelBuilder.Entity<TekstPortalu>()
            .HasIndex(e => e.Klucz)
            .IsUnique();

        modelBuilder.Entity<PozycjaSlownika>().HasData(PozycjeSlownikow());
        modelBuilder.Entity<TekstPortalu>().HasData(TekstyPortalu());
    }

    private static TekstPortalu[] TekstyPortalu()
    {
        return
        [
            new TekstPortalu { IdTekstuPortalu = 1, Klucz = "portal.start.hero", Tytul = "Witaj w swoim centrum ubezpieczeń", Tresc = "Sprawdzaj polisy, dodawaj zgłoszenia i korzystaj z aktualnych propozycji przygotowanych przez agentów.", Kolejnosc = 1, CzyAktywny = true, DataUtworzenia = new DateTime(2026, 6, 20), StatusRekordu = RecordStatus.Active },
            new TekstPortalu { IdTekstuPortalu = 2, Klucz = "portal.zgloszenia.hero", Tytul = "Zgłoszenia", Tresc = "Monitoruj zgłoszenia, statusy spraw oraz kontakt z opiekunem ubezpieczeniowym.", Kolejnosc = 2, CzyAktywny = true, DataUtworzenia = new DateTime(2026, 6, 20), StatusRekordu = RecordStatus.Active },
            new TekstPortalu { IdTekstuPortalu = 3, Klucz = "portal.wiadomosci.hero", Tytul = "Wiadomości", Tresc = "Przeglądaj wiadomości od opiekuna, powiadomienia systemowe i ważne informacje dotyczące polis.", Kolejnosc = 3, CzyAktywny = true, DataUtworzenia = new DateTime(2026, 6, 20), StatusRekordu = RecordStatus.Active },
            new TekstPortalu { IdTekstuPortalu = 4, Klucz = "portal.polisy.hero", Tytul = "Moje polisy", Tresc = "Sprawdzaj aktywne polisy, terminy ochrony, składki oraz produkty przypisane do Twojego konta.", Kolejnosc = 4, CzyAktywny = true, DataUtworzenia = new DateTime(2026, 6, 20), StatusRekordu = RecordStatus.Active },
            new TekstPortalu { IdTekstuPortalu = 5, Klucz = "portal.oferty.hero", Tytul = "Moje oferty", Tresc = "Porównaj przygotowane propozycje ubezpieczeniowe oraz aktualne komunikaty marketingowe dostępne w portalu klienta.", Kolejnosc = 5, CzyAktywny = true, DataUtworzenia = new DateTime(2026, 6, 20), StatusRekordu = RecordStatus.Active },
            new TekstPortalu { IdTekstuPortalu = 6, Klucz = "portal.agenci.hero", Tytul = "Agenci", Tresc = "Wybierz agenta, z którym chcesz porozmawiać o swojej polisie, zgłoszeniu lub nowej ofercie.", Kolejnosc = 6, CzyAktywny = true, DataUtworzenia = new DateTime(2026, 6, 20), StatusRekordu = RecordStatus.Active }
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

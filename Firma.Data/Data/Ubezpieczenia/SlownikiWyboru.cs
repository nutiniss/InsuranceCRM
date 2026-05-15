namespace Firma.Data.Data.Ubezpieczenia;

public static class SlownikiWyboru
{
    public static readonly IReadOnlyList<string> KategorieProduktu = new[]
    {
        "Komunikacyjne",
        "Majątkowe",
        "Życiowe",
        "Zdrowotne",
        "Turystyczne",
        "Firmowe"
    };

    public static readonly IReadOnlyList<string> StatusyOferty = new[]
    {
        "Nowa",
        "W przygotowaniu",
        "Wysłana do klienta",
        "Zaakceptowana",
        "Odrzucona",
        "Wygasła"
    };

    public static readonly IReadOnlyList<string> StatusyPolisy = new[]
    {
        "Aktywna",
        "Oczekuje na start",
        "Wznowienie",
        "Zakończona",
        "Wypowiedziana",
        "Anulowana"
    };

    public static readonly IReadOnlyList<string> TypyZadania = new[]
    {
        "Kontakt z klientem",
        "Przygotowanie oferty",
        "Weryfikacja dokumentów",
        "Obsługa zgłoszenia",
        "Odnowienie polisy",
        "Czynność administracyjna"
    };

    public static readonly IReadOnlyList<string> StatusyZadania = new[]
    {
        "Nowe",
        "W toku",
        "Oczekuje na klienta",
        "Oczekuje na dokumenty",
        "Zrealizowane",
        "Anulowane"
    };

    public static readonly IReadOnlyList<string> TypyZgloszenia = new[]
    {
        "Szkoda",
        "Zmiana danych",
        "Pytanie o polisę",
        "Reklamacja",
        "Prośba o kontakt",
        "Inne"
    };

    public static readonly IReadOnlyList<string> StatusyZgloszenia = new[]
    {
        "Nowe",
        "Przyjęte",
        "W analizie",
        "Oczekuje na klienta",
        "Zamknięte",
        "Odrzucone"
    };

    public static readonly IReadOnlyList<string> TypyWiadomosci = new[]
    {
        "E-mail",
        "SMS",
        "Telefon",
        "Notatka",
        "Powiadomienie systemowe"
    };

    public static readonly IReadOnlyList<string> RoleUzytkownika = new[]
    {
        "Agent",
        "Opiekun klienta",
        "Likwidator szkód",
        "Menedżer",
        "Administrator"
    };

    public static readonly IReadOnlyList<string> MetodyWyceny = new[]
    {
        "Taryfa standardowa",
        "Indywidualna kalkulacja",
        "Wycena ekspercka",
        "Kalkulator online",
        "Odnowienie na podstawie historii"
    };

    public static readonly IReadOnlyList<string> GrupyDocelowe = new[]
    {
        "Wszyscy klienci",
        "Nowi klienci",
        "Klienci indywidualni",
        "Klienci firmowi",
        "Klienci z aktywną polisą",
        "Klienci do odnowienia"
    };
}

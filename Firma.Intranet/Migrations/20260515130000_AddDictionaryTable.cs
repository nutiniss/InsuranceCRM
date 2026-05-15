using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Intranet.Migrations
{
    public partial class AddDictionaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PozycjaSlownika",
                columns: table => new
                {
                    IdPozycjiSlownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Wartosc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Kolejnosc = table.Column<int>(type: "int", nullable: false),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false),
                    StatusRekordu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjaSlownika", x => x.IdPozycjiSlownika);
                });

            migrationBuilder.InsertData(
                table: "PozycjaSlownika",
                columns: new[] { "IdPozycjiSlownika", "Typ", "Wartosc", "Kolejnosc", "CzyAktywna", "StatusRekordu" },
                values: new object[,]
                {
                    { 1, "KategoriaProduktu", "Komunikacyjne", 1, true, "Aktywny" },
                    { 2, "KategoriaProduktu", "Majątkowe", 2, true, "Aktywny" },
                    { 3, "KategoriaProduktu", "Życiowe", 3, true, "Aktywny" },
                    { 4, "KategoriaProduktu", "Zdrowotne", 4, true, "Aktywny" },
                    { 5, "KategoriaProduktu", "Turystyczne", 5, true, "Aktywny" },
                    { 6, "KategoriaProduktu", "Firmowe", 6, true, "Aktywny" },
                    { 7, "StatusOferty", "Nowa", 1, true, "Aktywny" },
                    { 8, "StatusOferty", "W przygotowaniu", 2, true, "Aktywny" },
                    { 9, "StatusOferty", "Wysłana do klienta", 3, true, "Aktywny" },
                    { 10, "StatusOferty", "Zaakceptowana", 4, true, "Aktywny" },
                    { 11, "StatusOferty", "Odrzucona", 5, true, "Aktywny" },
                    { 12, "StatusOferty", "Wygasła", 6, true, "Aktywny" },
                    { 13, "StatusPolisy", "Aktywna", 1, true, "Aktywny" },
                    { 14, "StatusPolisy", "Oczekuje na start", 2, true, "Aktywny" },
                    { 15, "StatusPolisy", "Wznowienie", 3, true, "Aktywny" },
                    { 16, "StatusPolisy", "Zakończona", 4, true, "Aktywny" },
                    { 17, "StatusPolisy", "Wypowiedziana", 5, true, "Aktywny" },
                    { 18, "StatusPolisy", "Anulowana", 6, true, "Aktywny" },
                    { 19, "TypZadania", "Kontakt z klientem", 1, true, "Aktywny" },
                    { 20, "TypZadania", "Przygotowanie oferty", 2, true, "Aktywny" },
                    { 21, "TypZadania", "Weryfikacja dokumentów", 3, true, "Aktywny" },
                    { 22, "TypZadania", "Obsługa zgłoszenia", 4, true, "Aktywny" },
                    { 23, "TypZadania", "Odnowienie polisy", 5, true, "Aktywny" },
                    { 24, "TypZadania", "Czynność administracyjna", 6, true, "Aktywny" },
                    { 25, "StatusZadania", "Nowe", 1, true, "Aktywny" },
                    { 26, "StatusZadania", "W toku", 2, true, "Aktywny" },
                    { 27, "StatusZadania", "Oczekuje na klienta", 3, true, "Aktywny" },
                    { 28, "StatusZadania", "Oczekuje na dokumenty", 4, true, "Aktywny" },
                    { 29, "StatusZadania", "Zrealizowane", 5, true, "Aktywny" },
                    { 30, "StatusZadania", "Anulowane", 6, true, "Aktywny" },
                    { 31, "TypZgloszenia", "Szkoda", 1, true, "Aktywny" },
                    { 32, "TypZgloszenia", "Zmiana danych", 2, true, "Aktywny" },
                    { 33, "TypZgloszenia", "Pytanie o polisę", 3, true, "Aktywny" },
                    { 34, "TypZgloszenia", "Reklamacja", 4, true, "Aktywny" },
                    { 35, "TypZgloszenia", "Prośba o kontakt", 5, true, "Aktywny" },
                    { 36, "TypZgloszenia", "Inne", 6, true, "Aktywny" },
                    { 37, "StatusZgloszenia", "Nowe", 1, true, "Aktywny" },
                    { 38, "StatusZgloszenia", "Przyjęte", 2, true, "Aktywny" },
                    { 39, "StatusZgloszenia", "W analizie", 3, true, "Aktywny" },
                    { 40, "StatusZgloszenia", "Oczekuje na klienta", 4, true, "Aktywny" },
                    { 41, "StatusZgloszenia", "Zamknięte", 5, true, "Aktywny" },
                    { 42, "StatusZgloszenia", "Odrzucone", 6, true, "Aktywny" },
                    { 43, "TypWiadomosci", "E-mail", 1, true, "Aktywny" },
                    { 44, "TypWiadomosci", "SMS", 2, true, "Aktywny" },
                    { 45, "TypWiadomosci", "Telefon", 3, true, "Aktywny" },
                    { 46, "TypWiadomosci", "Notatka", 4, true, "Aktywny" },
                    { 47, "TypWiadomosci", "Powiadomienie systemowe", 5, true, "Aktywny" },
                    { 48, "RolaUzytkownika", "Agent", 1, true, "Aktywny" },
                    { 49, "RolaUzytkownika", "Opiekun klienta", 2, true, "Aktywny" },
                    { 50, "RolaUzytkownika", "Likwidator szkód", 3, true, "Aktywny" },
                    { 51, "RolaUzytkownika", "Menedżer", 4, true, "Aktywny" },
                    { 52, "RolaUzytkownika", "Administrator", 5, true, "Aktywny" },
                    { 53, "MetodaWyceny", "Taryfa standardowa", 1, true, "Aktywny" },
                    { 54, "MetodaWyceny", "Indywidualna kalkulacja", 2, true, "Aktywny" },
                    { 55, "MetodaWyceny", "Wycena ekspercka", 3, true, "Aktywny" },
                    { 56, "MetodaWyceny", "Kalkulator online", 4, true, "Aktywny" },
                    { 57, "MetodaWyceny", "Odnowienie na podstawie historii", 5, true, "Aktywny" },
                    { 58, "GrupaDocelowa", "Wszyscy klienci", 1, true, "Aktywny" },
                    { 59, "GrupaDocelowa", "Nowi klienci", 2, true, "Aktywny" },
                    { 60, "GrupaDocelowa", "Klienci indywidualni", 3, true, "Aktywny" },
                    { 61, "GrupaDocelowa", "Klienci firmowi", 4, true, "Aktywny" },
                    { 62, "GrupaDocelowa", "Klienci z aktywną polisą", 5, true, "Aktywny" },
                    { 63, "GrupaDocelowa", "Klienci do odnowienia", 6, true, "Aktywny" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaSlownika_Typ_Wartosc",
                table: "PozycjaSlownika",
                columns: new[] { "Typ", "Wartosc" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "PozycjaSlownika");
        }
    }
}

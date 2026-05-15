using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
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
                columns: new[] { "IdPozycjiSlownika", "CzyAktywna", "Kolejnosc", "StatusRekordu", "Typ", "Wartosc" },
                values: new object[,]
                {
                    { 1, true, 1, "Aktywny", "KategoriaProduktu", "Komunikacyjne" },
                    { 2, true, 2, "Aktywny", "KategoriaProduktu", "Majątkowe" },
                    { 3, true, 3, "Aktywny", "KategoriaProduktu", "Życiowe" },
                    { 4, true, 4, "Aktywny", "KategoriaProduktu", "Zdrowotne" },
                    { 5, true, 5, "Aktywny", "KategoriaProduktu", "Turystyczne" },
                    { 6, true, 6, "Aktywny", "KategoriaProduktu", "Firmowe" },
                    { 7, true, 1, "Aktywny", "StatusOferty", "Nowa" },
                    { 8, true, 2, "Aktywny", "StatusOferty", "W przygotowaniu" },
                    { 9, true, 3, "Aktywny", "StatusOferty", "Wysłana do klienta" },
                    { 10, true, 4, "Aktywny", "StatusOferty", "Zaakceptowana" },
                    { 11, true, 5, "Aktywny", "StatusOferty", "Odrzucona" },
                    { 12, true, 6, "Aktywny", "StatusOferty", "Wygasła" },
                    { 13, true, 1, "Aktywny", "StatusPolisy", "Aktywna" },
                    { 14, true, 2, "Aktywny", "StatusPolisy", "Oczekuje na start" },
                    { 15, true, 3, "Aktywny", "StatusPolisy", "Wznowienie" },
                    { 16, true, 4, "Aktywny", "StatusPolisy", "Zakończona" },
                    { 17, true, 5, "Aktywny", "StatusPolisy", "Wypowiedziana" },
                    { 18, true, 6, "Aktywny", "StatusPolisy", "Anulowana" },
                    { 19, true, 1, "Aktywny", "TypZadania", "Kontakt z klientem" },
                    { 20, true, 2, "Aktywny", "TypZadania", "Przygotowanie oferty" },
                    { 21, true, 3, "Aktywny", "TypZadania", "Weryfikacja dokumentów" },
                    { 22, true, 4, "Aktywny", "TypZadania", "Obsługa zgłoszenia" },
                    { 23, true, 5, "Aktywny", "TypZadania", "Odnowienie polisy" },
                    { 24, true, 6, "Aktywny", "TypZadania", "Czynność administracyjna" },
                    { 25, true, 1, "Aktywny", "StatusZadania", "Nowe" },
                    { 26, true, 2, "Aktywny", "StatusZadania", "W toku" },
                    { 27, true, 3, "Aktywny", "StatusZadania", "Oczekuje na klienta" },
                    { 28, true, 4, "Aktywny", "StatusZadania", "Oczekuje na dokumenty" },
                    { 29, true, 5, "Aktywny", "StatusZadania", "Zrealizowane" },
                    { 30, true, 6, "Aktywny", "StatusZadania", "Anulowane" },
                    { 31, true, 1, "Aktywny", "TypZgloszenia", "Szkoda" },
                    { 32, true, 2, "Aktywny", "TypZgloszenia", "Zmiana danych" },
                    { 33, true, 3, "Aktywny", "TypZgloszenia", "Pytanie o polisę" },
                    { 34, true, 4, "Aktywny", "TypZgloszenia", "Reklamacja" },
                    { 35, true, 5, "Aktywny", "TypZgloszenia", "Prośba o kontakt" },
                    { 36, true, 6, "Aktywny", "TypZgloszenia", "Inne" },
                    { 37, true, 1, "Aktywny", "StatusZgloszenia", "Nowe" },
                    { 38, true, 2, "Aktywny", "StatusZgloszenia", "Przyjęte" },
                    { 39, true, 3, "Aktywny", "StatusZgloszenia", "W analizie" },
                    { 40, true, 4, "Aktywny", "StatusZgloszenia", "Oczekuje na klienta" },
                    { 41, true, 5, "Aktywny", "StatusZgloszenia", "Zamknięte" },
                    { 42, true, 6, "Aktywny", "StatusZgloszenia", "Odrzucone" },
                    { 43, true, 1, "Aktywny", "TypWiadomosci", "E-mail" },
                    { 44, true, 2, "Aktywny", "TypWiadomosci", "SMS" },
                    { 45, true, 3, "Aktywny", "TypWiadomosci", "Telefon" },
                    { 46, true, 4, "Aktywny", "TypWiadomosci", "Notatka" },
                    { 47, true, 5, "Aktywny", "TypWiadomosci", "Powiadomienie systemowe" },
                    { 48, true, 1, "Aktywny", "RolaUzytkownika", "Agent" },
                    { 49, true, 2, "Aktywny", "RolaUzytkownika", "Opiekun klienta" },
                    { 50, true, 3, "Aktywny", "RolaUzytkownika", "Likwidator szkód" },
                    { 51, true, 4, "Aktywny", "RolaUzytkownika", "Menedżer" },
                    { 52, true, 5, "Aktywny", "RolaUzytkownika", "Administrator" },
                    { 53, true, 1, "Aktywny", "MetodaWyceny", "Taryfa standardowa" },
                    { 54, true, 2, "Aktywny", "MetodaWyceny", "Indywidualna kalkulacja" },
                    { 55, true, 3, "Aktywny", "MetodaWyceny", "Wycena ekspercka" },
                    { 56, true, 4, "Aktywny", "MetodaWyceny", "Kalkulator online" },
                    { 57, true, 5, "Aktywny", "MetodaWyceny", "Odnowienie na podstawie historii" },
                    { 58, true, 1, "Aktywny", "GrupaDocelowa", "Wszyscy klienci" },
                    { 59, true, 2, "Aktywny", "GrupaDocelowa", "Nowi klienci" },
                    { 60, true, 3, "Aktywny", "GrupaDocelowa", "Klienci indywidualni" },
                    { 61, true, 4, "Aktywny", "GrupaDocelowa", "Klienci firmowi" },
                    { 62, true, 5, "Aktywny", "GrupaDocelowa", "Klienci z aktywną polisą" },
                    { 63, true, 6, "Aktywny", "GrupaDocelowa", "Klienci do odnowienia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaSlownika_Typ_Wartosc",
                table: "PozycjaSlownika",
                columns: new[] { "Typ", "Wartosc" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PozycjaSlownika");
        }
    }
}

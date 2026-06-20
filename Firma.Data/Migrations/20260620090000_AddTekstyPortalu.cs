using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTekstyPortalu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TekstPortalu",
                columns: table => new
                {
                    IdTekstuPortalu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Klucz = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Kolejnosc = table.Column<int>(type: "int", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusRekordu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TekstPortalu", x => x.IdTekstuPortalu);
                });

            migrationBuilder.InsertData(
                table: "TekstPortalu",
                columns: new[] { "IdTekstuPortalu", "CzyAktywny", "DataModyfikacji", "DataUtworzenia", "Klucz", "Kolejnosc", "StatusRekordu", "Tresc", "Tytul" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "portal.start.hero", 1, "Aktywny", "Sprawdzaj polisy, dodawaj zgłoszenia i korzystaj z aktualnych propozycji przygotowanych przez agentów.", "Witaj w swoim centrum ubezpieczeń" },
                    { 2, true, null, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "portal.zgloszenia.hero", 2, "Aktywny", "Monitoruj zgłoszenia, statusy spraw oraz kontakt z opiekunem ubezpieczeniowym.", "Zgłoszenia" },
                    { 3, true, null, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "portal.wiadomosci.hero", 3, "Aktywny", "Przeglądaj wiadomości od opiekuna, powiadomienia systemowe i ważne informacje dotyczące polis.", "Wiadomości" },
                    { 4, true, null, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "portal.polisy.hero", 4, "Aktywny", "Sprawdzaj aktywne polisy, terminy ochrony, składki oraz produkty przypisane do Twojego konta.", "Moje polisy" },
                    { 5, true, null, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "portal.oferty.hero", 5, "Aktywny", "Porównaj przygotowane propozycje ubezpieczeniowe oraz aktualne komunikaty marketingowe dostępne w portalu klienta.", "Moje oferty" },
                    { 6, true, null, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "portal.agenci.hero", 6, "Aktywny", "Wybierz agenta, z którym chcesz porozmawiać o swojej polisie, zgłoszeniu lub nowej ofercie.", "Agenci" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TekstPortalu_Klucz",
                table: "TekstPortalu",
                column: "Klucz",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TekstPortalu");
        }
    }
}

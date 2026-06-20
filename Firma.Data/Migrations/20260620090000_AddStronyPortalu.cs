using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStronyPortalu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StronaPortalu",
                columns: table => new
                {
                    IdStronyPortalu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TytulMenu = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NaglowekPomocniczy = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Kolejnosc = table.Column<int>(type: "int", nullable: false),
                    CzyWidocznaWMenu = table.Column<bool>(type: "bit", nullable: false),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusRekordu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StronaPortalu", x => x.IdStronyPortalu);
                });

            migrationBuilder.InsertData(
                table: "StronaPortalu",
                columns: new[] { "IdStronyPortalu", "CzyAktywna", "CzyWidocznaWMenu", "DataModyfikacji", "DataUtworzenia", "Kolejnosc", "NaglowekPomocniczy", "Slug", "StatusRekordu", "Tresc", "Tytul", "TytulMenu" },
                values: new object[,]
                {
                    { 1, true, true, null, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Instrukcje dla klientów", "jak-zglosic-szkode", "Aktywny", "Opisz zdarzenie, dołącz dokumenty i śledź status sprawy w zakładce Zgłoszenia. Po przyjęciu zgłoszenia opiekun skontaktuje się z Tobą z kolejnymi krokami.", "Jak zgłosić szkodę?", "Zgłoszenie szkody" },
                    { 2, true, true, null, new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Wsparcie w portalu klienta", "kontakt-z-agentem", "Aktywny", "Wybierz opiekuna w zakładce Agenci albo wyślij wiadomość z portalu. Agent pomoże w sprawach polis, ofert, zgłoszeń oraz odnowień.", "Kontakt z agentem", "Kontakt" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StronaPortalu_Slug",
                table: "StronaPortalu",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StronaPortalu");
        }
    }
}

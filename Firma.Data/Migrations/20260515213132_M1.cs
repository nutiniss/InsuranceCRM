using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.IdKlienta);
                });

            migrationBuilder.CreateTable(
                name: "ProduktUbezpieczeniowy",
                columns: table => new
                {
                    IdProduktuUbezpieczeniowego = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktUbezpieczeniowy", x => x.IdProduktuUbezpieczeniowego);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownik",
                columns: table => new
                {
                    IdUzytkownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownik", x => x.IdUzytkownika);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    IdOferty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerOferty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataWaznosci = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Przypis = table.Column<decimal>(type: "money", nullable: false),
                    IdKlienta = table.Column<int>(type: "int", nullable: false),
                    IdUzytkownika = table.Column<int>(type: "int", nullable: false),
                    IdProduktuUbezpieczeniowego = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.IdOferty);
                    table.ForeignKey(
                        name: "FK_Oferta_Klient_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klient",
                        principalColumn: "IdKlienta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oferta_ProduktUbezpieczeniowy_IdProduktuUbezpieczeniowego",
                        column: x => x.IdProduktuUbezpieczeniowego,
                        principalTable: "ProduktUbezpieczeniowy",
                        principalColumn: "IdProduktuUbezpieczeniowego",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oferta_Uzytkownik_IdUzytkownika",
                        column: x => x.IdUzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaMarketingowa",
                columns: table => new
                {
                    IdOfertyMarketingowej = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupaDocelowa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPublikacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataWaznosci = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false),
                    IdUzytkownika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaMarketingowa", x => x.IdOfertyMarketingowej);
                    table.ForeignKey(
                        name: "FK_OfertaMarketingowa_Uzytkownik_IdUzytkownika",
                        column: x => x.IdUzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wiadomosc",
                columns: table => new
                {
                    IdWiadomosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataWyslania = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CzyPrzeczytana = table.Column<bool>(type: "bit", nullable: false),
                    IdKlienta = table.Column<int>(type: "int", nullable: true),
                    IdUzytkownika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wiadomosc", x => x.IdWiadomosci);
                    table.ForeignKey(
                        name: "FK_Wiadomosc_Klient_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klient",
                        principalColumn: "IdKlienta");
                    table.ForeignKey(
                        name: "FK_Wiadomosc_Uzytkownik_IdUzytkownika",
                        column: x => x.IdUzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zgloszenie",
                columns: table => new
                {
                    IdZgloszenia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerZgloszenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZamkniecia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdKlienta = table.Column<int>(type: "int", nullable: false),
                    IdUzytkownika = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zgloszenie", x => x.IdZgloszenia);
                    table.ForeignKey(
                        name: "FK_Zgloszenie_Klient_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klient",
                        principalColumn: "IdKlienta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zgloszenie_Uzytkownik_IdUzytkownika",
                        column: x => x.IdUzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                });

            migrationBuilder.CreateTable(
                name: "Polisa",
                columns: table => new
                {
                    IdPolisy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerPolisy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoczatekOchrony = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KoniecOchrony = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Skladka = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKlienta = table.Column<int>(type: "int", nullable: false),
                    IdUzytkownika = table.Column<int>(type: "int", nullable: false),
                    IdProduktuUbezpieczeniowego = table.Column<int>(type: "int", nullable: false),
                    IdOferty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polisa", x => x.IdPolisy);
                    table.ForeignKey(
                        name: "FK_Polisa_Klient_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klient",
                        principalColumn: "IdKlienta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polisa_Oferta_IdOferty",
                        column: x => x.IdOferty,
                        principalTable: "Oferta",
                        principalColumn: "IdOferty");
                    table.ForeignKey(
                        name: "FK_Polisa_ProduktUbezpieczeniowy_IdProduktuUbezpieczeniowego",
                        column: x => x.IdProduktuUbezpieczeniowego,
                        principalTable: "ProduktUbezpieczeniowy",
                        principalColumn: "IdProduktuUbezpieczeniowego",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Polisa_Uzytkownik_IdUzytkownika",
                        column: x => x.IdUzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wycena",
                columns: table => new
                {
                    IdWyceny = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataWyceny = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetodaWyceny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WartoscPrzedmiotuUbezpieczenia = table.Column<decimal>(type: "money", nullable: false),
                    SumaUbezpieczenia = table.Column<decimal>(type: "money", nullable: false),
                    Skladka = table.Column<decimal>(type: "money", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdOferty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wycena", x => x.IdWyceny);
                    table.ForeignKey(
                        name: "FK_Wycena_Oferta_IdOferty",
                        column: x => x.IdOferty,
                        principalTable: "Oferta",
                        principalColumn: "IdOferty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zadanie",
                columns: table => new
                {
                    IdZadania = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRealizacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdKlienta = table.Column<int>(type: "int", nullable: true),
                    IdUzytkownika = table.Column<int>(type: "int", nullable: true),
                    IdZgloszenia = table.Column<int>(type: "int", nullable: true),
                    IdOferty = table.Column<int>(type: "int", nullable: true),
                    IdPolisy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadanie", x => x.IdZadania);
                    table.ForeignKey(
                        name: "FK_Zadanie_Klient_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klient",
                        principalColumn: "IdKlienta");
                    table.ForeignKey(
                        name: "FK_Zadanie_Oferta_IdOferty",
                        column: x => x.IdOferty,
                        principalTable: "Oferta",
                        principalColumn: "IdOferty");
                    table.ForeignKey(
                        name: "FK_Zadanie_Polisa_IdPolisy",
                        column: x => x.IdPolisy,
                        principalTable: "Polisa",
                        principalColumn: "IdPolisy");
                    table.ForeignKey(
                        name: "FK_Zadanie_Uzytkownik_IdUzytkownika",
                        column: x => x.IdUzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Zadanie_Zgloszenie_IdZgloszenia",
                        column: x => x.IdZgloszenia,
                        principalTable: "Zgloszenie",
                        principalColumn: "IdZgloszenia");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_IdKlienta",
                table: "Oferta",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_IdProduktuUbezpieczeniowego",
                table: "Oferta",
                column: "IdProduktuUbezpieczeniowego");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_IdUzytkownika",
                table: "Oferta",
                column: "IdUzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaMarketingowa_IdUzytkownika",
                table: "OfertaMarketingowa",
                column: "IdUzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Polisa_IdKlienta",
                table: "Polisa",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Polisa_IdOferty",
                table: "Polisa",
                column: "IdOferty",
                unique: true,
                filter: "[IdOferty] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Polisa_IdProduktuUbezpieczeniowego",
                table: "Polisa",
                column: "IdProduktuUbezpieczeniowego");

            migrationBuilder.CreateIndex(
                name: "IX_Polisa_IdUzytkownika",
                table: "Polisa",
                column: "IdUzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Wiadomosc_IdKlienta",
                table: "Wiadomosc",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Wiadomosc_IdUzytkownika",
                table: "Wiadomosc",
                column: "IdUzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Wycena_IdOferty",
                table: "Wycena",
                column: "IdOferty",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zadanie_IdKlienta",
                table: "Zadanie",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Zadanie_IdOferty",
                table: "Zadanie",
                column: "IdOferty");

            migrationBuilder.CreateIndex(
                name: "IX_Zadanie_IdPolisy",
                table: "Zadanie",
                column: "IdPolisy");

            migrationBuilder.CreateIndex(
                name: "IX_Zadanie_IdUzytkownika",
                table: "Zadanie",
                column: "IdUzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Zadanie_IdZgloszenia",
                table: "Zadanie",
                column: "IdZgloszenia");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenie_IdKlienta",
                table: "Zgloszenie",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenie_IdUzytkownika",
                table: "Zgloszenie",
                column: "IdUzytkownika");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfertaMarketingowa");

            migrationBuilder.DropTable(
                name: "Wiadomosc");

            migrationBuilder.DropTable(
                name: "Wycena");

            migrationBuilder.DropTable(
                name: "Zadanie");

            migrationBuilder.DropTable(
                name: "Polisa");

            migrationBuilder.DropTable(
                name: "Zgloszenie");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "ProduktUbezpieczeniowy");

            migrationBuilder.DropTable(
                name: "Uzytkownik");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Intranet.Migrations
{
    public partial class AddSoftDeleteStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusRekordu",
                table: "Zgloszenie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Aktywny");

            migrationBuilder.AddColumn<string>(
                name: "StatusRekordu",
                table: "Zadanie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Aktywny");

            migrationBuilder.AddColumn<string>(
                name: "StatusRekordu",
                table: "Wycena",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Aktywny");

            migrationBuilder.AddColumn<string>(
                name: "StatusRekordu",
                table: "Wiadomosc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Aktywny");

            migrationBuilder.AddColumn<string>(
                name: "StatusRekordu",
                table: "Uzytkownik",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Aktywny");

            migrationBuilder.AddColumn<string>(
                name: "StatusRekordu",
                table: "ProduktUbezpieczeniowy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Aktywny");

            migrationBuilder.AddColumn<string>(
                name: "StatusRekordu",
                table: "Polisa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Aktywny");

            migrationBuilder.AddColumn<string>(
                name: "StatusRekordu",
                table: "OfertaMarketingowa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Aktywny");

            migrationBuilder.AddColumn<string>(
                name: "StatusRekordu",
                table: "Oferta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Aktywny");

            migrationBuilder.AddColumn<string>(
                name: "StatusRekordu",
                table: "Klient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Aktywny");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "StatusRekordu", table: "Zgloszenie");
            migrationBuilder.DropColumn(name: "StatusRekordu", table: "Zadanie");
            migrationBuilder.DropColumn(name: "StatusRekordu", table: "Wycena");
            migrationBuilder.DropColumn(name: "StatusRekordu", table: "Wiadomosc");
            migrationBuilder.DropColumn(name: "StatusRekordu", table: "Uzytkownik");
            migrationBuilder.DropColumn(name: "StatusRekordu", table: "ProduktUbezpieczeniowy");
            migrationBuilder.DropColumn(name: "StatusRekordu", table: "Polisa");
            migrationBuilder.DropColumn(name: "StatusRekordu", table: "OfertaMarketingowa");
            migrationBuilder.DropColumn(name: "StatusRekordu", table: "Oferta");
            migrationBuilder.DropColumn(name: "StatusRekordu", table: "Klient");
        }
    }
}

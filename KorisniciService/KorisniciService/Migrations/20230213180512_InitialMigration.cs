using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KorisniciService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JavnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikID);
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "JavnoNadmetanjeID", "Naziv", "Sifra", "TipKorisnika" },
                values: new object[,]
                {
                    { new Guid("6e1a8ee2-c01d-484c-9da8-e50427fb298e"), new Guid("b49180d8-ff63-462d-8868-02c26ec0304c"), "Wynn Lagadu", "EjfkRqXrltLI", "Tehnicki sekretar" },
                    { new Guid("b0d223dd-c5f4-4bc3-ab9c-f83d8e374b1e"), new Guid("ce3c6508-b4d6-4b03-83c2-646baf4ed78b"), "Manuel Andriessen", "n4xxvQyQm", "Operater Nadmetanja" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}

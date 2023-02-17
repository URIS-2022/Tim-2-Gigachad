using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdresaService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Broj = table.Column<int>(type: "int", nullable: false),
                    Mesto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false),
                    Drzava = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Adresa",
                columns: new[] { "ID", "Broj", "Drzava", "Mesto", "PostanskiBroj", "Ulica" },
                values: new object[,]
                {
                    { new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"), 11, "Srbija", "Novi Sad", 22000, "Slavoja Perica" },
                    { new Guid("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"), 23, "Srbija", "Novi Sad", 22000, "Dositejeva" },
                    { new Guid("878100df-6973-4292-acb1-0c25b7ac2260"), 7, "Srbija", "Novi Sad", 22000, "Jevrejska" },
                    { new Guid("accad5a2-e5bc-4ff5-a5b7-fc38ab8a47fe"), 22, "Srbija", "Novi Sad", 22000, "Mise Dimitrijevica" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresa");
        }
    }
}

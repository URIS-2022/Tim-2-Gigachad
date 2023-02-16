using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LiceService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FizickaLica",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FizickaLica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lica",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FizickoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdresaLicaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefon1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Telefon2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrojRacuna = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OvlascenoLice = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lica_FizickaLica_FizickoLiceID",
                        column: x => x.FizickoLiceID,
                        principalTable: "FizickaLica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FizickaLica",
                columns: new[] { "ID", "Ime", "JMBG", "Prezime" },
                values: new object[,]
                {
                    { new Guid("32b7d397-b9d1-472d-bb40-542c68305098"), "Slavomir", "4058851174218", "Slavic" },
                    { new Guid("3a054c77-1bf4-4853-8937-8e36502a6848"), "Radomir", "0786741214886", "Radic" }
                });

            migrationBuilder.InsertData(
                table: "Lica",
                columns: new[] { "ID", "AdresaLicaID", "BrojRacuna", "Email", "FizickoLiceID", "OvlascenoLice", "Telefon1", "Telefon2" },
                values: new object[,]
                {
                    { new Guid("334f5277-a71c-4be8-b5da-5c9148b228f7"), new Guid("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"), "123134132", "email1@net.org", new Guid("3a054c77-1bf4-4853-8937-8e36502a6848"), true, "4211218533", "399461094" },
                    { new Guid("92e0d8e9-b221-42a6-9bb8-a80974aee937"), new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"), "132423425", "email2@net.org", new Guid("3a054c77-1bf4-4853-8937-8e36502a6848"), false, "377172253", "8048668952" },
                    { new Guid("f127642e-4d73-42f1-979d-6a506aea9bdc"), new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"), "123235243123", "email3@net.org", new Guid("32b7d397-b9d1-472d-bb40-542c68305098"), false, "4461663339", "4815540720" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lica_FizickoLiceID",
                table: "Lica",
                column: "FizickoLiceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lica");

            migrationBuilder.DropTable(
                name: "FizickaLica");
        }
    }
}

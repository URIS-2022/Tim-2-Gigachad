using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OvlascenoLiceService.Migrations
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
                name: "OvlascenaLica",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FizickoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdresaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefon1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Telefon2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrojRacuna = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvlascenaLica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OvlascenaLica_FizickaLica_FizickoLiceID",
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
                    { new Guid("194e73cb-831e-40da-9ec8-0751c04a6b28"), "Miladinko", "0925639560129", "Miladinkovic" },
                    { new Guid("4c504a89-419a-4f6f-8aae-31e0d3823e39"), "Radasinko", "6675836696997", "Radasinkovic" },
                    { new Guid("673eb87d-4a9f-4838-a542-3d4cef1b9495"), "Milasinko", "9195579483423", "Milasnkovic" },
                    { new Guid("8cc7d67a-61ed-4795-ad0a-fa882eda0a2b"), "Slavomirko", "4058851174218", "Slavimirkovic" },
                    { new Guid("af948f2a-745b-45bc-abc1-1f4da1727af4"), "Radomirko", "0786741214886", "Radimirkovic" }
                });

            migrationBuilder.InsertData(
                table: "OvlascenaLica",
                columns: new[] { "ID", "AdresaID", "BrojRacuna", "Email", "FizickoLiceID", "Telefon1", "Telefon2" },
                values: new object[,]
                {
                    { new Guid("145c1e74-7eb5-4eaa-bf6a-bb84921c871e"), new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"), "801272932440773", "email3@net.org", new Guid("673eb87d-4a9f-4838-a542-3d4cef1b9495"), "4461663339", "4815540720" },
                    { new Guid("1e24bea9-7df2-4d14-b224-c76fd77536dd"), new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"), "788066876873835", "email2@net.org", new Guid("af948f2a-745b-45bc-abc1-1f4da1727af4"), "377172253", "8048668952" },
                    { new Guid("7b50cce0-050d-4833-bbc7-6b910bb6da89"), new Guid("3aa0344b-57b5-450a-b83a-18c4555be65c"), "343658891760636", "email1@net.org", new Guid("af948f2a-745b-45bc-abc1-1f4da1727af4"), "4211218533", "399461094" },
                    { new Guid("904bd8b6-e268-4ca8-89fb-ef2750a74e19"), new Guid("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"), "854823918379735", "email4@net.org", new Guid("673eb87d-4a9f-4838-a542-3d4cef1b9495"), "2481909941", "" },
                    { new Guid("faea6877-c81e-4829-987e-ea68d5aea752"), new Guid("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"), "252614852215342", "email5@net.org", new Guid("4c504a89-419a-4f6f-8aae-31e0d3823e39"), "5528150968", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OvlascenaLica_FizickoLiceID",
                table: "OvlascenaLica",
                column: "FizickoLiceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OvlascenaLica");

            migrationBuilder.DropTable(
                name: "FizickaLica");
        }
    }
}

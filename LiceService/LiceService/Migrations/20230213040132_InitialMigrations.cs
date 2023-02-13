using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LiceService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
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

            migrationBuilder.InsertData(
                table: "FizickaLica",
                columns: new[] { "ID", "Ime", "JMBG", "Prezime" },
                values: new object[,]
                {
                    { new Guid("32b7d397-b9d1-472d-bb40-542c68305098"), "Slavomir", "4058851174218", "Slavic" },
                    { new Guid("3a054c77-1bf4-4853-8937-8e36502a6848"), "Radomir", "0786741214886", "Radic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FizickaLica");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdresaService.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Adresa",
                columns: new[] { "ID", "Broj", "Drzava", "Mesto", "PostanskiBroj", "Ulica" },
                values: new object[,]
                {
                    { new Guid("7fe60739-ee19-42cb-bb3c-4016f2214a47"), 12, "Srbija", "Beograd", 116468, "Stojana Protica" },
                    { new Guid("cbc77973-6f66-47b5-8b00-bdd9a2ab3650"), 16, "Srbija", "Beograd", 101801, "Brace Kovac" },
                    { new Guid("d84c6e01-ea38-4d2d-b6d3-ca8eb0766c1e"), 48, "Srbija", "Beograd", 116468, "Dalmatinska" },
                    { new Guid("e27e0caf-7d2b-4857-99de-71b63b503ae0"), 45, "Srbija", "Beograd", 101801, "Cerska" },
                    { new Guid("f94d04c3-0af9-4753-a40a-59ddd3b1fe2d"), 24, "Srbija", "Beograd", 114412, "Murmanska" },
                    { new Guid("febe5ad4-c954-4244-bdf5-54d351e36653"), 32, "Srbija", "Beograd", 112810, "Varvarinska" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adresa",
                keyColumn: "ID",
                keyValue: new Guid("7fe60739-ee19-42cb-bb3c-4016f2214a47"));

            migrationBuilder.DeleteData(
                table: "Adresa",
                keyColumn: "ID",
                keyValue: new Guid("cbc77973-6f66-47b5-8b00-bdd9a2ab3650"));

            migrationBuilder.DeleteData(
                table: "Adresa",
                keyColumn: "ID",
                keyValue: new Guid("d84c6e01-ea38-4d2d-b6d3-ca8eb0766c1e"));

            migrationBuilder.DeleteData(
                table: "Adresa",
                keyColumn: "ID",
                keyValue: new Guid("e27e0caf-7d2b-4857-99de-71b63b503ae0"));

            migrationBuilder.DeleteData(
                table: "Adresa",
                keyColumn: "ID",
                keyValue: new Guid("f94d04c3-0af9-4753-a40a-59ddd3b1fe2d"));

            migrationBuilder.DeleteData(
                table: "Adresa",
                keyColumn: "ID",
                keyValue: new Guid("febe5ad4-c954-4244-bdf5-54d351e36653"));
        }
    }
}

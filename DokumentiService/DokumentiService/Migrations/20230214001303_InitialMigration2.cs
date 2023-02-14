using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DokumentiService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dokumenti",
                columns: new[] { "DokumentID", "DatumDonosenja", "EksterniDokumentID", "InterniDokumentID", "Sablon", "StatusDokumenta" },
                values: new object[,]
                {
                    { new Guid("378ffff9-f997-4b7f-8c6e-c674918ef2e9"), new DateTime(2000, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3d0478c3-6220-4f6b-9438-b5e7fde84b02"), new Guid("7a8ef4cd-94f1-4dc8-bf89-9eb17374662b"), 5, 4 },
                    { new Guid("c9c1ccd3-e953-490e-b69c-cf903d8758f9"), new DateTime(2000, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d9157fc9-0fde-42db-b44f-98bdc39c8997"), new Guid("393dd1ca-ee17-42c7-aaac-6e560a45dfdd"), 5, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dokumenti",
                keyColumn: "DokumentID",
                keyValue: new Guid("378ffff9-f997-4b7f-8c6e-c674918ef2e9"));

            migrationBuilder.DeleteData(
                table: "Dokumenti",
                keyColumn: "DokumentID",
                keyValue: new Guid("c9c1ccd3-e953-490e-b69c-cf903d8758f9"));
        }
    }
}

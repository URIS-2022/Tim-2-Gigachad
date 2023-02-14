using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DokumentiService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokumenti",
                columns: table => new
                {
                    DokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EksterniDokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterniDokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumDonosenja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sablon = table.Column<int>(type: "int", nullable: true),
                    StatusDokumenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumenti", x => x.DokumentID);
                });

            migrationBuilder.CreateTable(
                name: "EksterniDokumenti",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PutanjaDokumenta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EksterniDokumenti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InterniDokumenti",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PutanjaDokumenta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterniDokumenti", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "EksterniDokumenti",
                columns: new[] { "ID", "PutanjaDokumenta" },
                values: new object[,]
                {
                    { new Guid("475b61f1-dccd-404a-a657-43fb9ec729ce"), "Ovo je samo da vidimo sta ce da pise" },
                    { new Guid("72922197-afd8-49ad-877b-6573b7d50714"), "Ovo je nesto nesto da vidimo sta ce da pise drugi deo brapoooo" }
                });

            migrationBuilder.InsertData(
                table: "InterniDokumenti",
                columns: new[] { "ID", "PutanjaDokumenta" },
                values: new object[,]
                {
                    { new Guid("858930f0-92ec-4975-b697-0c7afb2842de"), "Internal man" },
                    { new Guid("9813acc5-35f5-4d3b-886c-42a6aaf162b9"), "Internal bratskciiii" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokumenti");

            migrationBuilder.DropTable(
                name: "EksterniDokumenti");

            migrationBuilder.DropTable(
                name: "InterniDokumenti");
        }
    }
}

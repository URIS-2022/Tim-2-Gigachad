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
                name: "EksterniDokumenti",
                columns: table => new
                {
                    EksterniDokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PutanjaDokumenta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EksterniDokumenti", x => x.EksterniDokumentID);
                });

            migrationBuilder.CreateTable(
                name: "InterniDokumenti",
                columns: table => new
                {
                    InterniDokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PutanjaDokumenta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterniDokumenti", x => x.InterniDokumentID);
                });

            migrationBuilder.CreateTable(
                name: "Dokumenti",
                columns: table => new
                {
                    DokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EksterniDokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterniDokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumDonosenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sablon = table.Column<int>(type: "int", nullable: false),
                    StatusDokumenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumenti", x => x.DokumentID);
                    table.ForeignKey(
                        name: "FK_Dokumenti_EksterniDokumenti_EksterniDokumentID",
                        column: x => x.EksterniDokumentID,
                        principalTable: "EksterniDokumenti",
                        principalColumn: "EksterniDokumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dokumenti_InterniDokumenti_InterniDokumentID",
                        column: x => x.InterniDokumentID,
                        principalTable: "InterniDokumenti",
                        principalColumn: "InterniDokumentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EksterniDokumenti",
                columns: new[] { "EksterniDokumentID", "PutanjaDokumenta" },
                values: new object[,]
                {
                    { new Guid("475b61f1-dccd-404a-a657-43fb9ec729ce"), "Ovo je samo da vidimo sta ce da pise" },
                    { new Guid("72922197-afd8-49ad-877b-6573b7d50714"), "Ovo je nesto nesto da vidimo sta ce da pise drugi deo brapoooo" }
                });

            migrationBuilder.InsertData(
                table: "InterniDokumenti",
                columns: new[] { "InterniDokumentID", "PutanjaDokumenta" },
                values: new object[,]
                {
                    { new Guid("858930f0-92ec-4975-b697-0c7afb2842de"), "Internal man" },
                    { new Guid("9813acc5-35f5-4d3b-886c-42a6aaf162b9"), "Internal bratskciiii" }
                });

            migrationBuilder.InsertData(
                table: "Dokumenti",
                columns: new[] { "DokumentID", "DatumDonosenja", "EksterniDokumentID", "InterniDokumentID", "Sablon", "StatusDokumenta" },
                values: new object[,]
                {
                    { new Guid("378ffff9-f997-4b7f-8c6e-c674918ef2e9"), new DateTime(2000, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72922197-afd8-49ad-877b-6573b7d50714"), new Guid("9813acc5-35f5-4d3b-886c-42a6aaf162b9"), 5, 4 },
                    { new Guid("c9c1ccd3-e953-490e-b69c-cf903d8758f9"), new DateTime(2000, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("475b61f1-dccd-404a-a657-43fb9ec729ce"), new Guid("858930f0-92ec-4975-b697-0c7afb2842de"), 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dokumenti_EksterniDokumentID",
                table: "Dokumenti",
                column: "EksterniDokumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Dokumenti_InterniDokumentID",
                table: "Dokumenti",
                column: "InterniDokumentID");
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

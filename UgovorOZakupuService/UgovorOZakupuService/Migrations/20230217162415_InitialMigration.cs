using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UgovorOZakupuService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ugovori",
                columns: table => new
                {
                    UgovorOZakupuID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeoParceleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OvlascenoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JavnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumUgovora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrajanjeUgovora = table.Column<int>(type: "int", nullable: false),
                    TipGarancije = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugovori", x => x.UgovorOZakupuID);
                });

            migrationBuilder.InsertData(
                table: "Ugovori",
                columns: new[] { "UgovorOZakupuID", "DatumUgovora", "DeoParceleID", "DokumentID", "JavnoNadmetanjeID", "KupacID", "OvlascenoLiceID", "TipGarancije", "TrajanjeUgovora" },
                values: new object[,]
                {
                    { new Guid("1a41fbb4-ad86-4eec-be18-3ca94c1682cc"), new DateTime(2007, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ba05b8cf-42dc-4d35-b5bc-5f309b7ca43e"), new Guid("f9b78e65-f70d-4d3c-81a6-f0c687925d3d"), new Guid("c29c41d4-b729-41fe-a484-d04219fdb5a0"), new Guid("020c15d1-0928-4a1e-8fc1-45dcfa24c303"), new Guid("a332bcad-8049-4c73-a729-4fe6527b9ae7"), "BANKARSKAGARANCIJA", 8 },
                    { new Guid("dc662e18-1bb0-4f43-bb36-b20eab32a292"), new DateTime(2007, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("006c5863-3eb4-4e65-afab-f3f653dec82a"), new Guid("955b86da-6734-4972-93e5-9d46b0017bae"), new Guid("fa9c9d6b-e4ce-43b9-9bc9-04fc98872e19"), new Guid("035e91b3-55ab-4d36-b41b-95235a2efaa3"), new Guid("d3a26942-69f6-4f28-b5d2-05eba4b3ba1a"), "JEMSTVO", 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ugovori");
        }
    }
}

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
                columns: new[] { "UgovorOZakupuID", "DatumUgovora", "DeoParceleID", "DokumentID", "JavnoNadmetanjeID", "KupacID", "TipGarancije", "TrajanjeUgovora" },
                values: new object[,]
                {
                    { new Guid("1a41fbb4-ad86-4eec-be18-3ca94c1682cc"), new DateTime(2007, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3846acaf-3d0e-439a-bf27-85344934f2ca"), new Guid("c9c1ccd3-e953-490e-b69c-cf903d8758f9"), new Guid("5d62b2c0-d13c-4f74-840f-ad96bf204d69"), new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"), "BANKARSKAGARANCIJA", 8 },
                    { new Guid("dc662e18-1bb0-4f43-bb36-b20eab32a292"), new DateTime(2007, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("edf1f7ca-3b73-4cb8-8cfd-4bd615dd6ada"), new Guid("378ffff9-f997-4b7f-8c6e-c674918ef2e9"), new Guid("abec715b-03e0-4c9a-b97b-327f0af16823"), new Guid("ccc043c6-398c-485d-9840-092c0441ebe8"), "JEMSTVO", 8 }
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

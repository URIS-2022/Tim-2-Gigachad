using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UgovorOZakupuService.Migrations
{
    /// <inheritdoc />
    public partial class migracijaDeoParcele : Migration
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
                    { new Guid("1a41fbb4-ad86-4eec-be18-3ca94c1682cc"), new DateTime(2007, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3846acaf-3d0e-439a-bf27-85344934f2ca"), new Guid("8f807775-67a4-4c52-825c-63cc8da27c98"), new Guid("c29c41d4-b729-41fe-a484-d04219fdb5a0"), new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"), "BANKARSKAGARANCIJA", 8 },
                    { new Guid("dc662e18-1bb0-4f43-bb36-b20eab32a292"), new DateTime(2007, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("edf1f7ca-3b73-4cb8-8cfd-4bd615dd6ada"), new Guid("cbaf109e-4cba-4382-9a65-8eacf0567b4d"), new Guid("fa9c9d6b-e4ce-43b9-9bc9-04fc98872e19"), new Guid("ccc043c6-398c-485d-9840-092c0441ebe8"), "JEMSTVO", 8 }
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

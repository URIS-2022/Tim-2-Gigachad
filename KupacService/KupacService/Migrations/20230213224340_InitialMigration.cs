using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KupacService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OvlascenoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JavnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prioritet = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImaZabranu = table.Column<bool>(type: "bit", nullable: false),
                    DatumPocetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojKupovina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.KupacID);
                });

            migrationBuilder.InsertData(
                table: "Kupci",
                columns: new[] { "KupacID", "BrojKupovina", "DatumPocetkaZabrane", "DatumZavrsetkaZabrane", "ImaZabranu", "JavnoNadmetanjeID", "LiceID", "OvlascenoLiceID", "Prioritet" },
                values: new object[,]
                {
                    { new Guid("32b7d397-b9d1-472d-bb40-541c68305098"), 0, new DateTime(2003, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("32b7d397-b9d1-472d-bb40-542c68305018"), new Guid("32b7d397-b9d1-472d-bb40-542c68306098"), new Guid("32b7d397-b9d1-472d-bb40-542c68305094"), "stagodtobilo" },
                    { new Guid("32c7d397-b9d1-472d-bb40-542c68305098"), 50, new DateTime(2002, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("32b7d367-b9d1-472d-bb40-542c68305098"), new Guid("32b4d397-b9d1-472d-bb40-542c68305098"), new Guid("12b7d397-b9d1-472d-bb40-542c68305098"), "stagodtobilo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kupci");
        }
    }
}

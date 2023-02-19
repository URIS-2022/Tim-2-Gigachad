using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UplataService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uplate",
                columns: table => new
                {
                    UplataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JavnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojRacuna = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PozivNaBroj = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Iznos = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Uplatilac = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SvrhaUplate = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DatumUplate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.UplataID);
                });

            migrationBuilder.InsertData(
                table: "Uplate",
                columns: new[] { "UplataID", "BrojRacuna", "DatumUplate", "Iznos", "JavnoNadmetanjeID", "KupacID", "PozivNaBroj", "SvrhaUplate", "Uplatilac" },
                values: new object[,]
                {
                    { new Guid("167ef647-33c2-466c-b777-5271365bffbd"), "214-826330-03", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1550, new Guid("5d62b2c0-d13c-4f74-840f-ad96bf204d69"), new Guid("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"), "18096", "Racun za Telenor", "Sima Simic" },
                    { new Guid("460f3547-d626-49d7-92c4-6f96ae3714e0"), "005-417672-67", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 45000, new Guid("abec715b-03e0-4c9a-b97b-327f0af16823"), new Guid("ccc043c6-398c-485d-9840-092c0441ebe8"), "73609", "Uplata na racun", "Pera Peric" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uplate");
        }
    }
}

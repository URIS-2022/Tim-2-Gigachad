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
                    BrojRacuna = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PozivNaBroj = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Iznos = table.Column<int>(type: "int", nullable: false),
                    Uplatilac = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SvrhaUplate = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DatumUplate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KursnaLista = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.UplataID);
                });

            migrationBuilder.InsertData(
                table: "Uplate",
                columns: new[] { "UplataID", "BrojRacuna", "DatumUplate", "Iznos", "JavnoNadmetanjeID", "KupacID", "KursnaLista", "PozivNaBroj", "SvrhaUplate", "Uplatilac" },
                values: new object[,]
                {
                    { new Guid("167ef647-33c2-466c-b777-5271365bffbd"), "214-826330-03", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1550, new Guid("43d6bc15-a674-4552-abee-f3c3360db11e"), new Guid("47dc24c8-b4d4-49f2-a995-ba38d944a2b2"), "???????", "18096", "Racun za Telenor", "Sima Simic" },
                    { new Guid("460f3547-d626-49d7-92c4-6f96ae3714e0"), "005-417672-67", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 45000, new Guid("03b0680e-35b6-4449-9150-019b817d7cef"), new Guid("96e691db-3fee-44af-a0db-e51660b53bb4"), "???????", "73609", "Uplata na racun", "Pera Peric" }
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
